namespace SolarionGame.Domain.AggregatesModel.UserAggregate.Enums
{
    public enum UserTypeEnum
    {
        None = 0,
        Admin = 1,
        Common = 2,
    }

    public static class UserTypeEnumValue
    {
        public static string GetValue(UserTypeEnum type)
        {
            return type switch
            {
                UserTypeEnum.Admin => "Admin",
                UserTypeEnum.Common => "Comum",
                _ => "",
            };
        }
    }
}
