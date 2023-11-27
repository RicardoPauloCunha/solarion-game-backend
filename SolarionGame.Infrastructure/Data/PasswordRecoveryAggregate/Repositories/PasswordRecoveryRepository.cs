using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Models;
using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Repositories;

namespace SolarionGame.Infrastructure.Data.PasswordRecoveryAggregate.Repositories
{
    public class PasswordRecoveryRepository : IPasswordRecoveryRepository
    {
        private readonly SolarionGameContext _context;

        public PasswordRecoveryRepository(SolarionGameContext context)
        {
            _context = context;
        }

        public PasswordRecoveryModel GetActiveByUserId(long userId)
        {
            return _context
                .PasswordRecovery
                .FirstOrDefault(x => x.UserId == userId
                    && x.Active);
        }
    }
}
