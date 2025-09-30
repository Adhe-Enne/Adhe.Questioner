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
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(u => u.DNI).IsUnique();
            builder.Property(u => u.DNI)
                .HasMaxLength(9);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.PasswordHash)
                .IsRequired();
            builder.Property(u => u.PasswordSalt)
                .IsRequired();

            builder.Property(u => u.Image)
                .HasMaxLength(255);
            builder.Property(u => u.City)
                .HasMaxLength(50);
            builder.Property(u => u.Country)
                .HasMaxLength(50);

            builder.Property(u => u.Role)
                .IsRequired();

            builder.Property(u => u.IsActive)
                .IsRequired();
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
                .HasColumnType("char(36)");

            builder.Property(u => u.Email)
                .HasColumnType("varchar(255)");

            builder.Property(u => u.Name)
                .HasColumnType("varchar(50)");

            builder.Property(u => u.DNI)
                .HasColumnType("varchar(9)");

            builder.Property(u => u.PhoneNumber)
                .HasColumnType("varchar(20)");

            builder.Property(u => u.Image)
                .HasColumnType("varchar(255)");

            builder.Property(u => u.City)
                .HasColumnType("varchar(50)");

            builder.Property(u => u.Country)
                .HasColumnType("varchar(50)");

            builder.Property(u => u.PasswordHash)
                .HasColumnType("varbinary(max)");

            builder.Property(u => u.PasswordSalt)
                .HasColumnType("varbinary(max)");

            builder.Property(u => u.Role)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasConversion<string>() // Guarda como texto el enum
                .IsRequired();

            builder.Property(u => u.IsActive)
                .HasColumnType("bit")
                .HasDefaultValue(true);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
        }
    }
}
