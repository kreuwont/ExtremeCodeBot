using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ExtremeCodeBot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly ILogger _logger = Log.Logger.ForContext<UpdateController>();
        private readonly ITelegramBotClient _botClient;
        
        public UpdateController(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            try
            {
                if (update?.Message?.Type == MessageType.Text)
                {
                }
            }
            catch (Exception e)
            {
                _logger.Error(e, "error");
            }
            
            return Ok();
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok!");
        }
    }
}