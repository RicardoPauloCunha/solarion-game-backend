namespace SolarionGame.Domain.AggregatesService.EmailAggregate.Enums
{
    public enum EmailTemplateEnum
    {
        None = 0,
        PasswordRecovery = 1,
    }

    public static class EmailTemplateEnumValue
    {
        public static List<string> GetValue(EmailTemplateEnum type, string textToReplace)
        {
            return type switch
            {
                EmailTemplateEnum.PasswordRecovery => new List<string>() {
                    $"Foi solicitado a recuperação da sua senha. Seu código de verificação é: <b>{textToReplace}</b>.",
                    "Conclua o processo de recuperação em 30 minutos." },
                _ => new List<string>() { },
            };
        }
    }
}
