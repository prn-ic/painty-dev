using Communication.BusinessLayer.Configurations;
using Communication.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Communication.BusinessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Image> Images => Set<Image>();
        public DbSet<Friendship> Friendships => Set<Friendship>();
        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FriendshipConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImageConfiguration).Assembly);
            modelBuilder.Entity<UserRole>().HasData(new UserRole("user"), new UserRole("admin"));
        }
    }
}
