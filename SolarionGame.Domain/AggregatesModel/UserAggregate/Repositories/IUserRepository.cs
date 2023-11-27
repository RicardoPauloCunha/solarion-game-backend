using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;

namespace SolarionGame.Domain.AggregatesModel.UserAggregate.Repositories
{
    public interface IUserRepository
    {
        bool ExistsById(long id);
        bool ExistsByEmail(string email);
        long GetIdByEmail(string email);
        UserModel GetByEmail(string email);
    }
}
