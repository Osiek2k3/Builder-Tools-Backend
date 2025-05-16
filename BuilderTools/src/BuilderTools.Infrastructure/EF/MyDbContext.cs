using BuilderTools.Core.Model;
using BuilderTools.Infrastructure.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.EF
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BuilderTool> BuilderTools { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalArchive> RentalArchives { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BuilderToolConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new RentalConfiguration());
            modelBuilder.ApplyConfiguration(new RentalArchiveConfiguration());
        }
    }
}
