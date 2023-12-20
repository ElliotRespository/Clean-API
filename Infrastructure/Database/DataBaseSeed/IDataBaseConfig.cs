using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DataBaseSeed
{
    public interface IDataBaseConfig
    {
        public interface IDatabaseConfiguration
        {
            void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString);
        }
    }
}
