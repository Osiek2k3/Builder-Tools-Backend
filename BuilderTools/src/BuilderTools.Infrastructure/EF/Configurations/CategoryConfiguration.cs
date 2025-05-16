using BuilderTools.Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.EF.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(150);
            builder.Property(c => c.Description).HasMaxLength(500);
        }
    }
}
