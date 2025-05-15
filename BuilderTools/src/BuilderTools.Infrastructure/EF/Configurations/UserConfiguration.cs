using BuilderTools.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuilderTools.Infrastructure.EF.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Imie)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Nazwisko)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Uprawnienia);

            builder.Property(u => u.Adres)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Telefon)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.NIP)
                .HasMaxLength(20);

            builder.Property(u => u.KRS)
                .HasMaxLength(20);

            builder.Property(u => u.NazwaFirmy)
                .HasMaxLength(150);

            builder.Property(u => u.Rola)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Haslo)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
