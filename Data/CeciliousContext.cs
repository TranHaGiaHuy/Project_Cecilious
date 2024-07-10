
using Microsoft.EntityFrameworkCore;

using Project_Cecilious.Model;

namespace Project_Cecilious.Data

{
    public class CeciliousContext : DbContext
    {
        public CeciliousContext(DbContextOptions<CeciliousContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantAddress> RestaurantAddresses { get; set; }
        public DbSet<RestaurantCategory> RestaurantCategories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Review>().ToTable("Review");
            modelBuilder.Entity<Restaurant>().ToTable("Restaurant");
            modelBuilder.Entity<RestaurantAddress>().ToTable("RestaurantAddress");
            modelBuilder.Entity<RestaurantCategory>().ToTable("RestaurantCategory");
            modelBuilder.Entity<Dish>().ToTable("Dish");
            modelBuilder.Entity<DishCategory>().ToTable("DishCategory");


            modelBuilder.Entity<Review>()
       .HasKey(r => new { r.UserId, r.RestaurantId });
        }
    }
}

