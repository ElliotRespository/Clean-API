using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;


namespace Infrastructure.Database.DataBaseSeed
{
    internal class CommandLoginInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            Console.WriteLine($"Command Text: {command.CommandText}");
            return base.ReaderExecuting(command, eventData, result);
        }
    }
}
