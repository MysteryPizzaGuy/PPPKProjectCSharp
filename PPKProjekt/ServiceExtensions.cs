using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PPKProjekt.Repository;

namespace PPKProjekt
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            String connectionString = config["ConnectionStrings:SQLServerConnection"];
            new DatabaseFactory(connectionString);
            
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            //services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            services.AddScoped<IVozacRepository, VozacRepository>();
            services.AddScoped<IVoziloRepository, VoziloRepository>();
        }

    }
}
