using SolarionGame.Domain.SeedWork;

namespace SolarionGame.Infrastructure.Data
{
    public class Repository : IRepository
    {
        private readonly SolarionGameContext _context;

        public Repository(SolarionGameContext context)
        {
            _context = context;
        }

        public void Create<TModel>(TModel entity) where TModel : class
        {
            _context
                .Set<TModel>()
                .Add(entity);
        }

        public void Delete<TModel>(TModel entity) where TModel : class
        {
            _context
                .Set<TModel>()
                .Remove(entity);
        }

        public TModel GetById<TModel>(long id) where TModel : class
        {
            return _context
                .Set<TModel>()
                .Find(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update<TModel>(TModel entity) where TModel : class
        {
            _context
                .Set<TModel>()
                .Update(entity);
        }
    }
}
