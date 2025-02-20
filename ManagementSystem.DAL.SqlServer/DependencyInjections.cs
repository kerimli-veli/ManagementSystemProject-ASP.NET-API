using ManagementSystem.DAL.SqlServer.Context;
using ManagementSystem.DAL.SqlServer.UnitOfWork.SqlUnitOfWork;
using ManagementSystem.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ManagementSystem.DAL.SqlServer;

public static class DependencyInjections
{
    public static IServiceCollection AddSqlServerServices(this IServiceCollection services, string connectionString)
    {
       services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

       services.AddScoped<IUnitOfWork, SqlUnitOfWork>(opt =>
        {
            var dbContext = opt.GetRequiredService<AppDbContext>();
            return new SqlUnitOfWork(connectionString,dbContext);
        });

        return services;
    }
}
