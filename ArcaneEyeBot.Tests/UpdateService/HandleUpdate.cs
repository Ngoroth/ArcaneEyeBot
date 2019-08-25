using FakeItEasy;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ArcaneEyeBot.Tests.UpdateService
{
    [TestClass]
    public class HandleUpdate_Should
    {
        [TestMethod]
        public async Task DoRightThings()
        {
            var botConfigOptions = Options.Create<BotConfiguration>(new BotConfiguration { BotToken = "900742144:AAFEjD6QzgEOQw8jB0b0DXsmslXxYTQqxBw" });
            var botService = new Services.BotService(botConfigOptions);
            var photoService = new Services.PhotoService();
            var updateService = new Services.UpdateService(botService, photoService);

            //var update = A.Fake<Update>(builder => builder.ConfigureFake(upd => new Update { 
            //    Message = new Message{en});

            var update = A.Fake<Update>();

            await updateService.HandleUpdate(update);
        }
    }
}
