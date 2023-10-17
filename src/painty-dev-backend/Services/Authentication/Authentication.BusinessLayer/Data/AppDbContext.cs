using Authentication.BusinessLayer.Configurations;
using Authentication.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.BusinessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.Entity<UserRole>().HasData(new UserRole("user"), new UserRole("admin"));
        }
    }
}
