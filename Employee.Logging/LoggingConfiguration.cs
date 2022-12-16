using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Logging
{
    public static class LoggingConfiguration
    {
        public static IServiceCollection AddAppLogger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAppLogger, AppLogger>();
            return services;
        }
    }
}
