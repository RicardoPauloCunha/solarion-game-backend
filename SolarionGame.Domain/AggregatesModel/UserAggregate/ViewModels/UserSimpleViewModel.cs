namespace SolarionGame.Domain.AggregatesModel.UserAggregate.ViewModels
{
    public class UserSimpleViewModel
    {
        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public UserSimpleViewModel(long userId, string name, string email)
        {
            UserId = userId;
            Name = name;
            Email = email;
        }
    }
}
