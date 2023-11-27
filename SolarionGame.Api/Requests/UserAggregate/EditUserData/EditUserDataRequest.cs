using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using System.Runtime.Serialization;

namespace SolarionGame.Api.Requests.UserAggregate.EditUserData
{
    [DataContract]
    public class EditUserDataRequest : IRequest<ResultWrapper>
    {
        public long UserId { get; private set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        public EditUserDataRequest()
        {
            
        }

        public void SetComplement(long userId)
        {
            UserId = userId;
        }
    }
}
