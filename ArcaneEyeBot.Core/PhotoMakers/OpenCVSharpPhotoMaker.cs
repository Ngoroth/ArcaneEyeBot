using OpenCvSharp;
using OpenCvSharp.Extensions;
using ArcaneEyeBot.Core.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ArcaneEyeBot.Core.PhotoMakers
{
    public class OpenCVSharpPhotoMaker : IPhotoMaker
    {
        private readonly object locker = new object();

        public string MakePhoto()
        {
            var filePath = $"{Guid.NewGuid()}.png";
            using (var frame = new Mat())
            using (var capture = new VideoCapture(0))
            {
                capture.Open(0);

                Bitmap image = null;
                if (capture.IsOpened())
                {
                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                }

                using (var snapshot = new Bitmap(image))
                {
                    snapshot.Save(filePath, ImageFormat.Png);
                }
            }

            return filePath;
        }
    }
}
