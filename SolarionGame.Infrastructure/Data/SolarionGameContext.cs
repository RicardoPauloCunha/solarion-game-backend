using Microsoft.EntityFrameworkCore;
using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Models;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;
using SolarionGame.Infrastructure.Data.PasswordRecoveryAggregate.Mappings;
using SolarionGame.Infrastructure.Data.ScoreAggregate.Mappings;
using SolarionGame.Infrastructure.Data.UserAggregate.Mappings;

namespace SolarionGame.Infrastructure.Data
{
    public class SolarionGameContext : DbContext
    {
        public SolarionGameContext(DbContextOptions<SolarionGameContext> options) : base(options)
        {

        }

        public DbSet<PasswordRecoveryModel> PasswordRecovery { get; private set; }

        public DbSet<DecisionModel> Decision { get; private set; }
        public DbSet<ScoreModel> Score { get; private set; }

        public DbSet<UserModel> User { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PasswordRecoveryMapping());

            modelBuilder.ApplyConfiguration(new DecisionMapping());
            modelBuilder.ApplyConfiguration(new ScoreMapping());

            modelBuilder.ApplyConfiguration(new UserMapping());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
        }
    }
}
