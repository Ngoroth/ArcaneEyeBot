using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ArcaneEyeBot.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly object locker = new object();
        public void DeletePhoto(string filePath)
        {
            File.Delete(filePath);
        }

        public string MakePhoto()
        {
            lock (this.locker)
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
}
