using ExtremeCodeBot.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Telegram.Bot;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ExtremeCodeBot.Extensions
{
    public static class TelegramBotExtensions
    {
        public static void UseTelegramBotWebHook(this IApplicationBuilder applicationBuilder)
        {
            var provider = applicationBuilder.ApplicationServices;
            var lifetimeService = provider.GetRequiredService<IHostApplicationLifetime>();

            var logger = provider.GetRequiredService<ILogger<Startup>>();
            var botService = provider.GetRequiredService<ITelegramBotClient>();

            lifetimeService.ApplicationStarted.Register(
                async () =>
                {
                    var botSettings = provider.GetRequiredService<IOptions<BotSettings>>();
                    var webHookUrl = botSettings.Value.WebHookUrl;
                    
                    logger.LogInformation("Setting webhook to {webhookUrl}", webHookUrl);
                    await botService.SetWebhookAsync(webHookUrl);
                    var webHookInfo = await botService.GetWebhookInfoAsync();
                    logger.LogInformation("Webhook information: {webHookInfo}", JsonSerializer.Serialize(webHookInfo));
                });

            lifetimeService.ApplicationStopped.Register(
                async () =>
                {
                    await botService.DeleteWebhookAsync();
                    logger.LogInformation("Removed webhooks");
                });
        }
    }
}