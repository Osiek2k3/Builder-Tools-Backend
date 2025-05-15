
using BuilderTools.Core.Model;
using BuilderTools.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.EF
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
