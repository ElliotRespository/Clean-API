
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DataBaseSeed
{
    public class DataBaseConfig : IDataBaseConfig
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString).AddInterceptors(new CommandLoggingInterceptor()); ;

        }
    }
}
