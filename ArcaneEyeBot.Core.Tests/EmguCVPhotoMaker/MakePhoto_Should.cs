using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcaneEyeBot.Core.Tests.EmguCVPhotoMaker
{
    [TestClass]
    public class MakePhoto_Should
    {
        [TestMethod]
        public void MadePhoto()
        {
            var photoMaker = new PhotoMakers.EmguCVPhotoMaker();

            photoMaker.MakePhoto();
        }
    }
}
