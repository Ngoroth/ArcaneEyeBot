using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcaneEyeBot.Core;

namespace ArcaneEyeBot.Core.Tests.OpenCVSharpPhotoMaker
{
    [TestClass]
    public class MakePhoto_Should
    {
        [TestMethod]
        public void MadePhoto()
        {
            var photoMaker = new PhotoMakers.OpenCVSharpPhotoMaker();

            photoMaker.MakePhoto();
        }
    }
}
