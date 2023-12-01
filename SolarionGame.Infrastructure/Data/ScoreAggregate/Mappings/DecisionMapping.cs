using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;

namespace SolarionGame.Infrastructure.Data.ScoreAggregate.Mappings
{
    public class DecisionMapping : IEntityTypeConfiguration<DecisionModel>
    {
        public void Configure(EntityTypeBuilder<DecisionModel> builder)
        {
            builder.ToTable("tb_decision");

            builder.HasKey(x => new
            {
                x.ScoreId,
                x.DecisionType
            });

            builder.Property(x => x.DecisionType)
                .HasConversion<int>();
        }
    }
}
