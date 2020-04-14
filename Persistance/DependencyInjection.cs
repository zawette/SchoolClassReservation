using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["mysqlconnection:connectionString"];
            services.AddDbContext<SchoolClassReservationDbContext>(o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("Persistance")) );
            return services;
        }


        }
}
