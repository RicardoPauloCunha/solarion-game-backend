using Microsoft.EntityFrameworkCore;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Repositories;

namespace SolarionGame.Infrastructure.Data.ScoreAggregate.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly SolarionGameContext _context;

        public ScoreRepository(SolarionGameContext context)
        {
            _context = context;
        }

        public ScoreModel GetCompleteById(long id)
        {
            return _context
                .Score
                .Include(x => x.Decisions)
                .FirstOrDefault(x => x.ScoreId == id);
        }
    }
}
