using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace ArcaneEyeBot.Services
{
    public class BotService : IBotService
    {
        public TelegramBotClient Client { get; }

        public BotService(IOptions<BotConfiguration> config)
        {
            this.Client = new TelegramBotClient(config.Value.BotToken);
        }
    }
}
