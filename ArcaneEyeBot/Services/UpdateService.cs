using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ArcaneEyeBot.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService botService;
        private readonly IPhotoService photoService;

        public UpdateService(IBotService botService, IPhotoService photoService)
        {
            this.botService = botService;
            this.photoService = photoService;
        }
        public async Task HandleUpdate(Update update)
        {
            if(update.Message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return;
            }

            if(update.Message.Entities != null 
                && update.Message.Entities.Any(e => e.Type == Telegram.Bot.Types.Enums.MessageEntityType.BotCommand))
            {
                switch(update.Message.Text)
                {
                    case "/makephoto":
                        var fileName = this.photoService.MakePhoto();

                        using(var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
                        {
                            await this.botService.Client.SendPhotoAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream));
                        }

                        this.photoService.DeletePhoto(fileName);
                        break;

                }
            }
        }
    }
}
