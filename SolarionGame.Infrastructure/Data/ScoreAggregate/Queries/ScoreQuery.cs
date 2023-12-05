using Microsoft.EntityFrameworkCore;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Queries;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SolarionGame.Infrastructure.Data.ScoreAggregate.Queries
{
    public class ScoreQuery : IScoreQuery
    {
        private readonly SolarionGameContext _context;

        public ScoreQuery(SolarionGameContext context)
        {
            _context = context;
        }

        public List<ScoreViewModel> ListMyScores(long userId, long page)
        {
            return _context
                .Score
                .AsNoTracking()
                .OrderByDescending(x => x.ScoreId)
                .Where(x => (page == 0 || x.ScoreId < page)
                    && x.UserId == userId)
                .Take(10)
                .Select(x => new ScoreViewModel(
                    x.ScoreId,
                    x.CreationDate,
                    x.HeroType,
                    x.RatingType,
                    x.Decisions.Select(y => new DecisionViewModel(
                        y.DecisionType)),
                    ""))
                .ToList();
        }

        public List<ScoreViewModel> ListAllScores(long page, List<RatingTypeEnum> ratingTypes, List<HeroTypeEnum> heroTypes, int? lastMonths, DateTime? _startDate, DateTime? _endDate)
        {
            #region Types
            bool allRatingTypes = ratingTypes == null
                || !ratingTypes.Any()
                || ratingTypes.Count == Enum.GetNames(typeof(RatingTypeEnum)).Length - 1;

            bool allHeroTypes = heroTypes == null
                || !heroTypes.Any()
                || heroTypes.Count == Enum.GetNames(typeof(HeroTypeEnum)).Length - 1;
            #endregion

            #region Date
            bool noDate = false;
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = DateTime.Now;

            if (lastMonths != null && lastMonths > 0)
            {
                startDate = startDate.AddMonths(-((int)lastMonths - 1));
            }
            else if (_startDate != null && _endDate != null)
            {
                startDate = (DateTime)_startDate;
                endDate = (DateTime)_endDate;
            }
            else
            {
                noDate = true;
            }
            #endregion

            return _context
                .Score
                .AsNoTracking()
                .OrderByDescending(x => x.ScoreId)
                .Where(x => (page == 0 || x.ScoreId < page)
                    && (allRatingTypes || ratingTypes.Contains(x.RatingType))
                    && (allHeroTypes || heroTypes.Contains(x.HeroType))
                    && (noDate || (x.CreationDate.Date >= startDate.Date
                        && x.CreationDate.Date <= endDate.Date)))
                .Take(10)
                .Select(x => new ScoreViewModel(
                    x.ScoreId,
                    x.CreationDate,
                    x.HeroType,
                    x.RatingType,
                    x.Decisions.Select(y => new DecisionViewModel(
                        y.DecisionType)),
                    x.User.Name))
                .ToList();
        }

        public ScoreIndicatorsViewModel GetScoreIndicators(int? lastMonths, DateTime? _startDate, DateTime? _endDate)
        {
            #region Date
            DateTime startDate = new(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime endDate = DateTime.Now;

            if (lastMonths != null && lastMonths > 0)
            {
                startDate = startDate.AddMonths(-((int)lastMonths - 1));
            }
            else if (_startDate != null && _endDate != null)
            {
                startDate = (DateTime)_startDate;
                endDate = (DateTime)_endDate;
            }
            else
            {
                startDate = startDate.AddMonths(-2);
            }
            #endregion

            var scores = _context
                .Score
                .AsNoTracking()
                .OrderByDescending(x => x.ScoreId)
                .Where(x => x.CreationDate.Date >= startDate.Date
                        && x.CreationDate.Date <= endDate.Date)
                .Select(x => new {
                    x.CreationDate,
                    x.HeroType,
                    x.RatingType })
                .ToList()
                .OrderBy(x => x.CreationDate);

            #region Qtde. aventuras
            var adventuresValues = scores
                .GroupBy(x => x.CreationDate.ToString("MM/yyyy"))
                .Select(x => {
                    float total = x.Count();

                    return new ChartValueViewModel(
                        x.Key,
                        total); })
                .ToList();

            var adventuresChart = new ChartViewModel(
                "Qtde. aventuras",
                scores.Count(),
                adventuresValues);
            #endregion

            List<string> requiredDatas = HeroTypeEnumValue.ListAllValues();

            #region Seleção de classes
            var heroCharts = scores
                .GroupBy(x => x.HeroType)
                .OrderBy(x => x.Key)
                .Select(x => {
                    var values = x
                        .GroupBy(y => y.CreationDate.ToString("MM/yyyy"))
                        .Select(y => {
                            int quantity = y.Count();

                            return new ChartValueViewModel(
                                y.Key,
                                quantity); })
                        .ToList();

                    float total = x.Count();

                    return new ChartViewModel(
                        HeroTypeEnumValue.GetValue(x.Key),
                        total,
                        values); })
                .ToList();

            FormatChartValues(heroCharts, requiredDatas);
            #endregion

            Dictionary<string, int> columnsQuantity = new();
            requiredDatas = RatingTypeEnumValue.ListAllValues();

            #region Pontuações obtidas
            var ratingCharts = scores
                .GroupBy(x => x.RatingType)
                .OrderBy(x => x.Key)
                .Select(x => {
                    var values = x
                        .GroupBy(y => y.CreationDate.ToString("MM/yyyy"))
                        .Select(y => {
                            int quantity = y.Count();

                            if (columnsQuantity.ContainsKey(y.Key))
                                columnsQuantity[y.Key] += quantity;
                            else
                                columnsQuantity.Add(y.Key, quantity);

                            return new ChartValueViewModel(
                                y.Key,
                                quantity); })
                        .ToList();

                    float total = x.Count();

                    return new ChartViewModel(
                        RatingTypeEnumValue.GetValue(x.Key),
                        total,
                        values); })
                .ToList();

            ratingCharts.ForEach(x =>
            {
                x.Values.ForEach(y =>
                {
                    y.SetValue((y.Value / columnsQuantity[y.Column]) * 100);
                });
            });

            FormatChartValues(ratingCharts, requiredDatas);
            #endregion

            #region Formatar coluna de datas
            List<ChartViewModel> charts = new() { adventuresChart };
            charts.AddRange(heroCharts);
            charts.AddRange(ratingCharts);

            FormatChartColumnDates(charts, startDate, endDate);
            #endregion

            ScoreIndicatorsViewModel scoreIndicators = new(
                adventuresChart,
                heroCharts,
                ratingCharts);

            return scoreIndicators;
        }

        private static void FormatChartValues(List<ChartViewModel> charts, List<string> requiredDatas)
        {
            if (requiredDatas.Count == 0)
                return;

            for (int i = 0, j = 0, count = 0, length = charts.Count; i < requiredDatas.Count; i++)
            {
                if (count == length || requiredDatas[i] != charts[j]?.Description)
                {
                    charts.Insert(i, new ChartViewModel(
                        requiredDatas[i],
                        0,
                        new List<ChartValueViewModel>()));
                }
                else
                {
                    count++;
                }

                if (j == i)
                    j++;
            }
        }

        private static void FormatChartColumnDates(List<ChartViewModel> charts, DateTime startDate, DateTime endDate)
        {
            List<string> columns = new();

            while (startDate <= endDate)
            {
                columns.Add(startDate.ToString("MM/yyyy"));
                startDate = startDate.AddMonths(1);
            }

            charts.ForEach(x =>
            {
                for (int i = 0, j = 0, count = 0, length = x.Values.Count; i < columns.Count; i++)
                {
                    if (count == length || columns[i] != x.Values[j]?.Column)
                    {
                        x.Values.Insert(i, new ChartValueViewModel(
                            columns[i],
                            0));
                    }
                    else
                    {
                        count++;
                    }

                    if (j == i)
                        j++;
                }
            });
        }
    }
}
