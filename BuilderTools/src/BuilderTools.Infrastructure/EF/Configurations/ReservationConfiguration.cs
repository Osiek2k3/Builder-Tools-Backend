using BuilderTools.Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.EF.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.ReservationId);

            builder.Property(r => r.ReservationDate).IsRequired();
            builder.Property(r => r.StartDate).IsRequired();
            builder.Property(r => r.EndDate).IsRequired();

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
