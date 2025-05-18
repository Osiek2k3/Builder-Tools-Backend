using BuilderTools.Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.EF.Configurations
{
    public class BuilderToolConfiguration : IEntityTypeConfiguration<BuilderTool>
    {
        public void Configure(EntityTypeBuilder<BuilderTool> builder)
        {
            builder.HasKey(b => b.BuilderToolId);

            builder.Property(b => b.Name).IsRequired().HasMaxLength(150);
            builder.Property(b => b.Permission).IsRequired();
            builder.Property(b => b.PricePerDay).HasColumnType("decimal(18,2)");
            builder.Property(bt => bt.Image)
                .HasColumnType("bytea").IsRequired();

            // Relacja 1 BuilderTool : 1 Category
            builder.HasOne<Category>()
                   .WithMany()
                   .HasForeignKey(b => b.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
