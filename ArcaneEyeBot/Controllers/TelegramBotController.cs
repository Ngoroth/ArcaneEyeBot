using System;
using System.Linq;
using System.Threading.Tasks;
using ArcaneEyeBot.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MihaZupan;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ArcaneEyeBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        private readonly TelegramBotClient telegramBotClient;
        private readonly IPhotoMaker photoMaker;

        public TelegramBotController(IOptions<BotConfiguration> botConfig, IPhotoMaker photoMaker)
        {
            this.telegramBotClient = string.IsNullOrEmpty(botConfig.Value.Socks5Host)
                ? new TelegramBotClient(botConfig.Value.BotToken)
                : new TelegramBotClient(
                    botConfig.Value.BotToken,
                    new HttpToSocks5Proxy(botConfig.Value.Socks5Host, botConfig.Value.Socks5Port, botConfig.Value.Login, botConfig.Value.Password));
            this.photoMaker = photoMaker;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            try
            {
                if (update.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                {
                    return this.Ok();
                }

                if (update.Message.Entities != null
                    && update.Message.Entities.Any(e => e.Type == Telegram.Bot.Types.Enums.MessageEntityType.BotCommand))
                {
                    switch (update.Message.Text)
                    {
                        case "/makephoto":
                            var fileName = this.photoMaker.MakePhoto();

                            using (var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
                            {
                                await this.telegramBotClient.SendPhotoAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                            }

                            System.IO.File.Delete(fileName);
                            break;

                    }
                }
            }
            catch (Exception e)
            {
                //await this.telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, e.Message);
                this.StatusCode(500);
            }
            
            return this.Ok();
        }
    }
}