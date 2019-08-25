using ArcaneEyeBot.Services;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcaneEyeBot;
using Telegram.Bot.Types;

namespace ArcaneEyeBot.Tests.TelegramBotController
{
    [TestClass]
    public class Post_Should
    {
        public async Task ReturnOk()
        {
            var botService = A.Fake<IBotService>();
            var photoService = A.Fake<IPhotoService>();
            var updateService = A.Fake<IUpdateService>();
            var update = A.Fake<Update>();
            var controller = new Controllers.TelegramBotController(updateService);

            var result = await controller.Post(update);
        }
    }
}
