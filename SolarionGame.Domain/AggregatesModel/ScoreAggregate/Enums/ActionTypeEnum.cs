namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums
{
    public enum ActionTypeEnum
    {
        None = 0,
        CH1_AC2_Warrior = 1,
        CH1_AC2_Healer = 2,
        CH1_AC2_Mage = 3,
        CH3_AC1_Front = 4,
        CH3_AC1_Back = 5,
        CH4_AC2_Fight = 6,
        CH4_AC2_Run = 7,
        CH4_AC3_Weapon = 8,
        CH4_AC3_Shield = 9,
        CH5_AC2_Left = 10,
        CH5_AC2_Right = 11,
        CH6_AC3_Run = 12,
        CH6_AC3_Break = 13,
        CH8_AC3_Warrior_Sword = 14,
        CH8_AC3_Warrior_Shield = 15,
        CH8_AC3_Healer_Heal_Warrior = 16,
        CH8_AC3_Healer_Heal_Mage = 17,
        CH8_AC3_Mage_Lightning = 18,
        CH8_AC3_Mage_Shield = 19,
    }

    public static class ActionTypeEnumValue
    {
        public static string GetValue(ActionTypeEnum type)
        {
            return type switch
            {
                ActionTypeEnum.CH1_AC2_Warrior => "Guerreiro. Gosto de abordagens diretas.",
                ActionTypeEnum.CH1_AC2_Healer => "Curandeiro. Prefiro ajudar os outros.",
                ActionTypeEnum.CH1_AC2_Mage => "Mago. Uma mente aguçada é a mais poderosa das lâminas.",
                ActionTypeEnum.CH3_AC1_Front => "Ir na frente. A sorte favorece os ousados.",
                ActionTypeEnum.CH3_AC1_Back => "Procurar por uma entrada dos fundos. Vamos continuar escondidos.",
                ActionTypeEnum.CH4_AC2_Fight => "Luta com o esqueleto.",
                ActionTypeEnum.CH4_AC2_Run => "Foge.",
                ActionTypeEnum.CH4_AC3_Weapon => "Empunha suas armas.",
                ActionTypeEnum.CH4_AC3_Shield => "Levanta seus escudos.",
                ActionTypeEnum.CH5_AC2_Left => "Entra no corredor à esquerda.",
                ActionTypeEnum.CH5_AC2_Right => "Sobe as escadas à direita.",
                ActionTypeEnum.CH6_AC3_Run => "Sai o mais rápido possível.",
                ActionTypeEnum.CH6_AC3_Break => "Destrói as capsulas.",
                ActionTypeEnum.CH8_AC3_Warrior_Sword => "Ataca com sua espada.",
                ActionTypeEnum.CH8_AC3_Warrior_Shield => "Usa seu escudo para defender dos inimigos.",
                ActionTypeEnum.CH8_AC3_Healer_Heal_Warrior => "Cura o guerreiro.",
                ActionTypeEnum.CH8_AC3_Healer_Heal_Mage => "Cura o mago.",
                ActionTypeEnum.CH8_AC3_Mage_Lightning => "Lança um ‘Raio Puro’ em Xarth.",
                ActionTypeEnum.CH8_AC3_Mage_Shield => "Lança um ‘Encantamento de Escudo’ em seus amigos.",
                _ => "",
            };
        }
    }
}
