using Domain.Models;
using Domain.Models.Animalmodels;
using Domain.Models.UserModels;
using Infrastructure.Database.DataBaseSeed;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.SqlDataBases
{
    public class RealDatabase : DbContext
    {
        public RealDatabase()
        {

        }

        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options)
        {

        }

        public virtual DbSet<Dog> Dogs { get; set; }

        public virtual DbSet<Cat> Cats { get; set; }

        public virtual DbSet<UserModel> Users { get; set; }

        public virtual DbSet<UserAnimalModel> UserAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS; Database=CleanApi_demo_db; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ändra från sammansatt nyckel till en enkel primärnyckel
            modelBuilder.Entity<UserAnimalModel>()
                .HasKey(ua => ua.UserAnimalId); // Använd UserAnimalId som primärnyckel

            // Konfigurera relationerna som tidigare
            modelBuilder.Entity<UserAnimalModel>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAnimals)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAnimalModel>()
                .HasOne(ua => ua.Animal)
                .WithMany(a => a.UserAnimals)
                .HasForeignKey(ua => ua.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            DataBaseSeedHelper.SeedData(modelBuilder);
        }

    }
}
