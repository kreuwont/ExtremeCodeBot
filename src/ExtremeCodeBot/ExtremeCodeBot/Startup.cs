using System;
using ExtremeCodeBot.Configurations;
using ExtremeCodeBot.Extensions;
using ExtremeCodeBot.Infrastructure;
using ExtremeCodeBot.Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using Telegram.Bot;

namespace ExtremeCodeBot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.Configure<BotSettings>(Configuration.GetSection("BotSettings"));
            services.AddSingleton<ITelegramBotClient>(provider =>
            {
                var botSettings = provider.GetRequiredService<IOptions<BotSettings>>();
                return new TelegramBotClient(botSettings.Value.BotToken);
            });

            services.Configure<DbSettings>(Configuration.GetSection("DbSettings"));
            services.AddDbContext<DefaultDbContext>((provider, options) =>
            {
                var dbSettings = provider.GetRequiredService<IOptions<DbSettings>>();
                options.UseNpgsql(DbSettings.GetConnectionString(dbSettings.Value));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseTelegramBotWebHook();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            Log.Logger.Information("Start in {Timezone}", TimeZoneInfo.Local.Id);
        }
    }
}