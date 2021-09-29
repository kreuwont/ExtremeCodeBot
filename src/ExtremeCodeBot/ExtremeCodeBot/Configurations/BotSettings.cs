using System.ComponentModel.DataAnnotations;

namespace ExtremeCodeBot.Configurations
{
    public class BotSettings
    {
        [Required]
        public string BotToken { get; set; }
        
        [Required]
        public string WebHookUrl { get; set; }
    }
}