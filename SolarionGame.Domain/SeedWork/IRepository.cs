namespace SolarionGame.Domain.SeedWork
{
    public interface IRepository
    {
        void Create<TModel>(TModel entity) where TModel : class;
        void Update<TModel>(TModel entity) where TModel : class;
        void Delete<TModel>(TModel entity) where TModel : class;
        TModel GetById<TModel>(long id) where TModel : class;
        Task Save();
    }
}
