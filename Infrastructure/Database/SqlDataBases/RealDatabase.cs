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

        public virtual DbSet<UserAnimal> UserAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS; Database=CleanApi_demo_db; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Configuring the many-to-many relationship
            modelBuilder.Entity<UserAnimal>()
                .HasKey(ua => new { ua.UserId, ua.AnimalId });

            modelBuilder.Entity<UserAnimal>()
                .HasOne(ua => ua.user)
                .WithMany(ua => ua.UserAnimals)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserAnimal>()
                .HasOne(ua => ua.Animal)
                .WithMany(a => a.UserAnimals)
                .HasForeignKey(ua => ua.AnimalId);
            DataBaseSeedHelper.SeedData(modelBuilder);
        }

    }
}
