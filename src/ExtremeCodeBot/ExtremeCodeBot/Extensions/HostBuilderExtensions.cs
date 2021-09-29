using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace ExtremeCodeBot.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder builder, Action<LoggerConfiguration, IConfiguration>? configureLogger = null)
        {
            builder.ConfigureLogging((context, builder) =>
            {
                builder.ClearProviders();
                builder.AddSerilog(CreateLogger(context.Configuration, configureLogger));
            });
            return builder;
        }

        private static ILogger CreateLogger(IConfiguration configuration, Action<LoggerConfiguration, IConfiguration>? configureLogger)
        {
            var loggerBuilder = new LoggerConfiguration()
                .Enrich.FromLogContext();
            
            configureLogger?.Invoke(loggerBuilder, configuration);
            return loggerBuilder.CreateLogger();
        }
    }
}