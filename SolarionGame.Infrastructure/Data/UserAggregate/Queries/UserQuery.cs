using Microsoft.EntityFrameworkCore;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Queries;
using SolarionGame.Domain.AggregatesModel.UserAggregate.ViewModels;

namespace SolarionGame.Infrastructure.Data.UserAggregate.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly SolarionGameContext _context;

        public UserQuery(SolarionGameContext context)
        {
            _context = context;
        }

        public UserSimpleViewModel GetLoggedUser(long userId)
        {
            return _context
                .User
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => new UserSimpleViewModel(
                    x.UserId,
                    x.Name,
                    x.Email))
                .FirstOrDefault();
        }
    }
}
