using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using System.Runtime.Serialization;

namespace SolarionGame.Api.Requests.UserAggregate.CreateCommonUser
{
    [DataContract]
    public class CreateCommonUserRequest : IRequest<ResultWrapper>
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        public CreateCommonUserRequest()
        {

        }
    }
}
