namespace SolarionGame.Domain.AggregatesModel.ScoreAggregate.Enums
{
    public enum DecisionTypeEnum
    {
        None = 0,
        CH1_ACT2_DEC_Warrior = 1,
        CH1_ACT2_DEC_Healer = 2,
        CH1_ACT2_DEC_Mage = 3,
        CH3_ACT1_DEC_Front = 4,
        CH3_ACT1_DEC_Back = 5,
        CH4_ACT2_DEC_Fight = 6,
        CH4_ACT2_DEC_Run = 7,
        CH4_ROT1_ACT1_DEC_Weapon = 8,
        CH4_ROT1_ACT1_DEC_Shield = 9,
        CH5_ACT2_DEC_Left = 10,
        CH5_ACT2_DEC_Right = 11,
        CH6_ACT3_DEC_Run = 12,
        CH6_ACT3_DEC_Break = 13,
        CH8_ROT_WAR_AC2_DEC_Sword = 14,
        CH8_ROT_WAR_AC2_DEC_Shield = 15,
        CH8_ROT_HEA_AC3_DEC_Warrior = 16,
        CH8_ROT_HEA_AC3_DEC_Mage = 17,
        CH8_ROT_MAG_AC2_DEC_Lightning = 18,
        CH8_ROT_MAG_AC2_DEC_Shield = 19,
    }

    public static class DecisionTypeEnumValue
    {
        public static string GetValue(DecisionTypeEnum type)
        {
            return type switch
            {
                DecisionTypeEnum.CH1_ACT2_DEC_Warrior => "Guerreiro. Gosto de abordagens diretas.",
                DecisionTypeEnum.CH1_ACT2_DEC_Healer => "Curandeiro. Prefiro ajudar os outros.",
                DecisionTypeEnum.CH1_ACT2_DEC_Mage => "Mago. Uma mente aguçada é a mais poderosa das lâminas.",
                DecisionTypeEnum.CH3_ACT1_DEC_Front => "Ir na frente. A sorte favorece os ousados.",
                DecisionTypeEnum.CH3_ACT1_DEC_Back => "Procurar por uma entrada dos fundos. Vamos continuar escondidos.",
                DecisionTypeEnum.CH4_ACT2_DEC_Fight => "Luta com o esqueleto.",
                DecisionTypeEnum.CH4_ACT2_DEC_Run => "Foge.",
                DecisionTypeEnum.CH4_ROT1_ACT1_DEC_Weapon => "Empunha suas armas.",
                DecisionTypeEnum.CH4_ROT1_ACT1_DEC_Shield => "Levanta seus escudos.",
                DecisionTypeEnum.CH5_ACT2_DEC_Left => "Entra no corredor à esquerda.",
                DecisionTypeEnum.CH5_ACT2_DEC_Right => "Sobe as escadas à direita.",
                DecisionTypeEnum.CH6_ACT3_DEC_Run => "Sai o mais rápido possível.",
                DecisionTypeEnum.CH6_ACT3_DEC_Break => "Destrói as capsulas.",
                DecisionTypeEnum.CH8_ROT_WAR_AC2_DEC_Sword => "Ataca com sua espada.",
                DecisionTypeEnum.CH8_ROT_WAR_AC2_DEC_Shield => "Usa seu escudo para defender dos inimigos.",
                DecisionTypeEnum.CH8_ROT_HEA_AC3_DEC_Warrior => "Cura o Guerreiro.",
                DecisionTypeEnum.CH8_ROT_HEA_AC3_DEC_Mage => "Cura o Mago.",
                DecisionTypeEnum.CH8_ROT_MAG_AC2_DEC_Lightning => "Lança um ‘Raio Puro’ em Xarth.",
                DecisionTypeEnum.CH8_ROT_MAG_AC2_DEC_Shield => "Lança um ‘Encantamento de Escudo’ em seus amigos.",
                _ => "",
            };
        }
    }
}
