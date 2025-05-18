using BuilderTools.Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.EF.Configurations
{
    public class RentalArchiveConfiguration : IEntityTypeConfiguration<RentalArchive>
    {
        public void Configure(EntityTypeBuilder<RentalArchive> builder)
        {
            builder.HasKey(r => r.RentalId);

            builder.Property(r => r.DataStart).IsRequired();
            builder.Property(r => r.DataEnd).IsRequired();
            builder.Property(r => r.Amount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(r => r.Deposit).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(r => r.ExtraCost).HasColumnType("decimal(18,2)");
            builder.Property(r => r.Notes).HasMaxLength(500);

            // Relacja do User
            builder.HasOne<User>()
                   .WithMany()
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relacja do BuilderTool
            builder.HasOne<BuilderTool>()
                   .WithMany()
                   .HasForeignKey(r => r.BuilderToolId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
