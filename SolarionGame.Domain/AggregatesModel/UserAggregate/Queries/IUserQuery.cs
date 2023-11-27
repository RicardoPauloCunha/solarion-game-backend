using SolarionGame.Domain.AggregatesModel.UserAggregate.ViewModels;

namespace SolarionGame.Domain.AggregatesModel.UserAggregate.Queries
{
    public interface IUserQuery
    {
        UserSimpleViewModel GetLoggedUser(long userId);
    }
}
