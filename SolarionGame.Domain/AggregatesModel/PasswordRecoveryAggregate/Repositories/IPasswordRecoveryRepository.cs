using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Models;

namespace SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Repositories
{
    public interface IPasswordRecoveryRepository
    {
        PasswordRecoveryModel GetActiveByUserId(long userId); 
    }
}
