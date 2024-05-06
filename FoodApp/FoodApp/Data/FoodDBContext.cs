using FoodApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FoodApp.Data
{
    public class FoodDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<UserSensitiveIngredient> UserSensitiveIngredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            IConfiguration config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);


            modelBuilder.Entity<UserSensitiveIngredient>()
                .HasKey(ui => new { ui.UserId, ui.IngredientId });

            modelBuilder.Entity<UserSensitiveIngredient>()
                .HasOne(ui => ui.User)
                .WithMany(u => u.UserSensitiveIngredients)
                .HasForeignKey(ui => ui.UserId);

            modelBuilder.Entity<UserSensitiveIngredient>()
                .HasOne(ui => ui.Ingredient)
                .WithMany(i => i.UserSensitiveIngredients)
                .HasForeignKey(ri => ri.IngredientId);
        }

    }
}
