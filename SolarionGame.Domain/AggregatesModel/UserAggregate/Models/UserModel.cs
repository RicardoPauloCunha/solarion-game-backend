using FluentValidation;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Enums;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Validators;

namespace SolarionGame.Domain.AggregatesModel.UserAggregate.Models
{
    public class UserModel
    {
        public long UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreationDate { get; private set; }
        public UserTypeEnum UserType { get; private set; }

        public UserModel()
        {
            
        }

        public UserModel(string name, string email, string password, UserTypeEnum userType)
        {
            SetName(name);
            SetEmail(email);
            SetPassword(password);
            CreationDate = DateTime.Now;
            UserType = userType;
        }

        public void Validate()
        {
            UserValidator validator = new();
            validator.ValidateAndThrow(this);
        }

        public void SetName(string name)
        {
            Name = name.Trim().ToUpper();
        }

        public void SetEmail(string email)
        {
            Email = email.Trim().ToUpper();
        }

        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}
