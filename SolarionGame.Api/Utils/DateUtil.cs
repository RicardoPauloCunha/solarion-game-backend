namespace SolarionGame.Api.Utils
{
    public static class DateUtil
    {
        public static DateTime? StringToDate(string dateString)
        {
            DateTime? date = null;

            if (!string.IsNullOrEmpty(dateString))
            {
                List<int> dateValues = dateString.Split("-").Select(x => int.Parse(x)).ToList();

                date = new DateTime(dateValues[0], dateValues[1], dateValues[2]);
            }

            return date;
        }
    }
}
