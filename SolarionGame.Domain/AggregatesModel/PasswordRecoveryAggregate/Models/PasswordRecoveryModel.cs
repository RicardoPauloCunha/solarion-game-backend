using FluentValidation;
using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Validators;
using System.Security.Cryptography;
using System.Text;

namespace SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Models
{
    public class PasswordRecoveryModel
    {
        public long PasswordRecoveryId { get; private set; }
        public string VerificationCode { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreationDate { get; private set; }

        public long UserId { get; private set; }

        public PasswordRecoveryModel()
        {
            
        }

        public PasswordRecoveryModel(long userId)
        {
            DefineVerificationCode();
            Active = true;
            CreationDate = DateTime.Now;
            UserId = userId;
        }

        public void Validate()
        {
            PasswordRecoveryValidator validator = new();
            validator.ValidateAndThrow(this);
        }

        private void DefineVerificationCode()
        {
            string charSet = "0123456789";
            var chars = charSet.ToCharArray();
            var data = new byte[1];

            var crypto = RandomNumberGenerator.Create();
            crypto.GetNonZeroBytes(data);

            data = new byte[6];

            crypto.GetNonZeroBytes(data);

            var result = new StringBuilder(6);

            foreach (var b in data)
                result.Append(chars[b % (chars.Length)]);

            string code = result.ToString();

            VerificationCode = code;
        }

        public void UpdateCreationDate()
        {
            CreationDate = DateTime.Now;
        }

        public bool DurationIsValid()
        {
            return CreationDate > DateTime.Now.AddMinutes(-30);
        }

        public void Disable()
        {
            Active = false;
        }
    }
}
