using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using System.Runtime.Serialization;

namespace SolarionGame.Api.Requests.PasswordRecoveryAggregate.SolicitPasswordRecovery
{
    [DataContract]
    public class SolicitPasswordRecoveryRequest : IRequest<ResultWrapper>
    {
        [DataMember]
        public string Email { get; set; }

        public SolicitPasswordRecoveryRequest()
        {
            
        }
    }
}
