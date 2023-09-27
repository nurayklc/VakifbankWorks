using Microsoft.EntityFrameworkCore;
using NLayeredAPI.Data.Context;

namespace NLayeredAPI.Extension
{
    public static class DbContextEntension
    {
        public static void AddAppDbContextDI(this IServiceCollection services, IConfiguration configuration)
        {
            var dbType = configuration.GetConnectionString("DbType").ToString();
            if (dbType == "SQL")
            {
                var dbConfigSqlServer = configuration.GetConnectionString("SqlServerConnection");
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConfigSqlServer));
            }
            else if (dbType == "POSTGRESQL")
            {
                var dbConfigPostgreSql = configuration.GetConnectionString("PostgreSqlConnection");
                services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbConfigPostgreSql));
            }
        }
    }
}
