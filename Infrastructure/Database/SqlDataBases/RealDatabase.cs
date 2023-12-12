using Domain.Models.Animalmodels;
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

        public DbSet<Dog> Dogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS; Database=CleanApi_demo_db; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DataBaseSeedHelper.SeedData(modelBuilder);
        }

    }
}
