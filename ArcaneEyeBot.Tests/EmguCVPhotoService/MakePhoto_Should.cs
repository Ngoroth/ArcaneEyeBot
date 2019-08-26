using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcaneEyeBot.Tests.EmguCVPhotoService
{
    [TestClass]
    public class MakePhoto_Should
    {
        [TestMethod]
        public void CreatePhoto()
        {
            var photoService = new Core.PhotoMakers.EmguCVPhotoService();
            photoService.MakePhoto();
        }
    }
}
