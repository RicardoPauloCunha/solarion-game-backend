using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using System.Runtime.Serialization;

namespace SolarionGame.Api.Requests.UserAggregate.Login
{
    [DataContract]
    public class LoginRequest : IRequest<ResultWrapper>
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        public LoginRequest()
        {

        }
    }
}
