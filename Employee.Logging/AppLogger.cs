using Microsoft.Extensions.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Logging
{
    public class AppLogger : IAppLogger
    {
        public Logger logger { get; set; }
        public AppLogger(IConfiguration configuration)
        {

            var fileName = configuration["Serilog:FileName"];
            var fileLoggerConfig = configuration.GetSection("Serilog:WriteTo").GetChildren().FirstOrDefault(x => x["Name"] == "File");

            logger = new LoggerConfiguration()
                    .ReadFrom
                    .Configuration(configuration)
                    .WriteTo.File(new JsonFormatter(renderMessage: true),
                     path: fileName,
                     levelSwitch: new LoggingLevelSwitch((LogEventLevel)Enum.Parse(typeof(LogEventLevel), fileLoggerConfig["Args:levelSwitch"])),
                     rollingInterval: (RollingInterval)Enum.Parse(typeof(RollingInterval), fileLoggerConfig["Args:rollingInterval"]),
                     rollOnFileSizeLimit: Convert.ToBoolean(fileLoggerConfig["Args:rollOnFileSizeLimit"]),
                     shared: Convert.ToBoolean(fileLoggerConfig["Args:shared"]),
                     retainedFileCountLimit: Convert.ToInt32(fileLoggerConfig["Args:retainedFileCountLimit"]))
                    .Enrich.FromLogContext()
                    .CreateLogger();
        }

        public void LogError(Exception ex, string messageTemplate, params object[] propertyValues)
        {
            logger.Error(ex, messageTemplate, propertyValues);
        }

        public void LogInformation(string messageTemplate, params object[] propertyValues)
        {
            logger.Information(messageTemplate, propertyValues);
        }
    }
}
