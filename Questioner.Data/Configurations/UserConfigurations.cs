using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questioner.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Configurations;

namespace Questioner.Data.Configurations
{
    public class UserConfigurations : EntityTypeBaseConfiguration<Entities.User>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.DNI).IsUnique();
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(u => u.DNI)
                .HasMaxLength(9)
                .HasColumnType("varchar(9)");

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(u => u.Image)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            builder.Property(u => u.City)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")

                .HasMaxLength(50);
            builder.Property(u => u.Country)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasColumnType("longblob");

            builder.Property(u => u.PasswordSalt)
                .IsRequired()
                .HasColumnType("longblob");

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasConversion<string>();

            builder.Property(u => u.IsActive)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(true);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
        }
    }
}
