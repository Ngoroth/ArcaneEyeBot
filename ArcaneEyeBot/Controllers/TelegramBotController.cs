using System;
using System.Threading.Tasks;
using ArcaneEyeBot.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace ArcaneEyeBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        private readonly IUpdateService updateService;

        public TelegramBotController(IUpdateService updateService)
        {
            this.updateService = updateService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            try
            {
                await this.updateService.HandleUpdate(update);
            }
            catch (Exception e)
            {
                this.StatusCode(500);
            }
            
            return this.Ok();
        }
    }
}