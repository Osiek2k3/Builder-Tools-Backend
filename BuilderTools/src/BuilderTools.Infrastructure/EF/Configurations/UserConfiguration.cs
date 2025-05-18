using BuilderTools.Core.Model;
using BuilderTools.Core.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuilderTools.Infrastructure.EF.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Permission);
            builder.Property(u => u.Address).IsRequired().HasMaxLength(250);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(u => u.NIP).HasMaxLength(20);
            builder.Property(u => u.KRS).HasMaxLength(20);
            builder.Property(u => u.CompanyName).HasMaxLength(150);
            builder.Property(u => u.Role)
                .HasConversion(
                v => v.Value,
                v => new Role(v)).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(255);
        }
    }
}
