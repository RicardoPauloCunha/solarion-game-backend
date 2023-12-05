namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums
{
    public enum RatingTypeEnum
    {
        None = 0,
        A = 1,
        B = 2,
        C = 3,
        D = 4,
    }

    public static class RatingTypeEnumValue
    {
        public static string GetValue(RatingTypeEnum type)
        {
            return type switch
            {
                RatingTypeEnum.A => "A",
                RatingTypeEnum.B => "B",
                RatingTypeEnum.C => "C",
                RatingTypeEnum.D => "D",
                _ => "",
            };
        }

        public static List<string> ListAllValues()
        {
            List<RatingTypeEnum> list = new()
            {
                RatingTypeEnum.A,
                RatingTypeEnum.B,
                RatingTypeEnum.C,
                RatingTypeEnum.D,
            };

            return list.Select(x => GetValue(x)).ToList();
        }
    }
}
