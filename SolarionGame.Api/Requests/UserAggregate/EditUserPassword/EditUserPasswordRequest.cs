using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using System.Runtime.Serialization;

namespace SolarionGame.Api.Requests.UserAggregate.EditUserPassword
{
    [DataContract]
    public class EditUserPasswordRequest : IRequest<ResultWrapper>
    {
        public long UserId { get; private set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string NewPassword { get; set; }

        public EditUserPasswordRequest()
        {
            
        }

        public void SetComplement(long userId)
        {
            UserId = userId;
        }
    }
}
