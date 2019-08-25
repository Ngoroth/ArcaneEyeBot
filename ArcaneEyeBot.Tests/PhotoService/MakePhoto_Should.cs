using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcaneEyeBot.Tests.PhotoService
{
    [TestClass]
    public class MakePhoto_Should
    {
        [TestMethod]
        public void NotThrowException()
        {
            var photoService = new Services.PhotoService();
            photoService.MakePhoto();
        }
    }
}
