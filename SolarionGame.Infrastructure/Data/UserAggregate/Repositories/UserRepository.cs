using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories;

namespace SolarionGame.Infrastructure.Data.UserAggregate.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SolarionGameContext _context;

        public UserRepository(SolarionGameContext context)
        {
            _context = context;
        }

        public bool ExistsById(long id)
        {
            return _context
                .User
                .Any(x => x.UserId == id);
        }

        public bool ExistsByEmail(string email)
        {
            return _context
                .User
                .Any(x => x.Email == email);
        }

        public UserModel GetByEmail(string email)
        {
            return _context
                .User
                .FirstOrDefault(x => x.Email == email);
        }

        public long GetIdByEmail(string email)
        {
            return _context
                .User
                .Where(x => x.Email == email)
                .Select(x => x.UserId)
                .FirstOrDefault();
        }
    }
}
