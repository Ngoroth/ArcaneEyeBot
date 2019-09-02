using ArcaneEyeBot.Core.Interfaces;
using System;
using Emgu.CV;

namespace ArcaneEyeBot.Core.PhotoMakers
{
    public class EmguCVPhotoMaker : IPhotoMaker
    {
        public string MakePhoto()
        {
            var filePath = $"{Guid.NewGuid()}.png";
            using (var capture = new Capture(0))
            {
                capture.FlipVertical = true;
                var image = capture.QueryFrame();
                image.Save(filePath);
            }
                return filePath;
        }
    }
}
