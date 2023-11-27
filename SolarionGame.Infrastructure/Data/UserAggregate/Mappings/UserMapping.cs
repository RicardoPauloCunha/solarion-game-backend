using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;

namespace SolarionGame.Infrastructure.Data.UserAggregate.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("tb_user");

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Name)
                .HasMaxLength(40);

            builder.Property(x => x.Email)
                .HasMaxLength(80);

            builder.Property(x => x.Password)
                .HasMaxLength(120);

            builder.Property(x => x.UserType)
                .HasConversion<int>();
        }
    }
}
