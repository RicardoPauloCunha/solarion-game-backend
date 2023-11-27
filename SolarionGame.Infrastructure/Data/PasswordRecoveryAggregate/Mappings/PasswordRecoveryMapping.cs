using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarionGame.Domain.AggregatesModel.PasswordRecoveryAggregate.Models;
using SolarionGame.Domain.AggregatesModel.UserAggregate.Models;

namespace SolarionGame.Infrastructure.Data.PasswordRecoveryAggregate.Mappings
{
    public class PasswordRecoveryMapping : IEntityTypeConfiguration<PasswordRecoveryModel>
    {
        public void Configure(EntityTypeBuilder<PasswordRecoveryModel> builder)
        {
            builder.ToTable("tb_password_recovery");

            builder.HasKey(x => x.PasswordRecoveryId);

            builder.Property(x => x.VerificationCode)
                .HasMaxLength(6);

            builder.HasOne<UserModel>()
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
