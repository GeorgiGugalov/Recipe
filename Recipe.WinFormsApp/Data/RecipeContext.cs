using Microsoft.EntityFrameworkCore;
using Recipe.WinFormsApp.Data.Models;

namespace Recipe.WinFormsApp.Data
{
    public class RecipeContext : DbContext
    {
        public DbSet<Models.Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
        }
        public RecipeContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //DESKTOP-J4IDPFS\SQLEXPRESS na ismet
                //DESKTOP-E42ENN9\SQLEXPRESS na kris
                optionsBuilder.UseSqlServer("Server=DESKTOP-3IMUUA7;Database=Recipes;Integrated Security=True;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Recipe mapping
            modelBuilder.Entity<Models.Recipe>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Models.Recipe>()
                .HasMany(r => r.Ingredients);

            modelBuilder.Entity<Models.Recipe>()
                .HasMany(r => r.Ingredients)
                .WithOne(i => i.Recipe)
                .HasForeignKey(i => i.RecipeId);

            modelBuilder.Entity<Models.Recipe>()
                .Property(r => r.Id)
                .UseIdentityColumn();

            //Ingredient mapping
            modelBuilder.Entity<Models.Ingredient>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Ingredient>()
                .Property(r => r.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Recipe)           
                .WithMany(r => r.Ingredients)    
                .HasForeignKey(i => i.RecipeId);
        }
    }
}
