﻿using MediatR;
using SolarionGame.Api.Configurations.Wrappers;
using System.Runtime.Serialization;

namespace SolarionGame.Api.Requests.PasswordRecoveryAggregate.ReplyPasswordRecovery
{
    [DataContract]
    public class ReplyPasswordRecoveryRequest : IRequest<ResultWrapper>
    {
        [DataMember]
        public string VerificationCode { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        public ReplyPasswordRecoveryRequest()
        {
            
        }
    }
}
