using Infrastructure.Database.DataBaseSeed;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class DataBaseConfig : IDataBaseConfig
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString).AddInterceptors(new CommandLoggingInterceptor()); ;

        }
    }
}
