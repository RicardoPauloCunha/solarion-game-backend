namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums
{
    public enum HeroTypeEnum
    {
        None = 0,
        Warrior = 1,
        Healer = 2,
        Mage = 3,
    }

    public static class HeroTypeEnumValue
    {
        public static string GetValue(HeroTypeEnum type)
        {
            return type switch
            {
                HeroTypeEnum.Warrior => "Guerreiro",
                HeroTypeEnum.Healer => "Curandeiro",
                HeroTypeEnum.Mage => "Mago",
                _ => "",
            };
        }
    }
}
