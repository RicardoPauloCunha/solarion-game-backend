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
    }
}
