using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarionGame.Domain.AggregatesModel.ScoreAggregate.Models;

namespace SolarionGame.Infrastructure.Data.ScoreAggregate.Mappings
{
    public class ScoreMapping : IEntityTypeConfiguration<ScoreModel>
    {
        public void Configure(EntityTypeBuilder<ScoreModel> builder)
        {
            builder.ToTable("tb_score");

            builder.HasKey(x => x.ScoreId);

            builder.Property(x => x.HeroType)
                .HasConversion<int>();

            builder.Property(x => x.RatingType)
                .HasConversion<int>();

            builder.HasMany(x => x.Decisions)
                .WithOne()
                .HasForeignKey(x => x.ScoreId);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
