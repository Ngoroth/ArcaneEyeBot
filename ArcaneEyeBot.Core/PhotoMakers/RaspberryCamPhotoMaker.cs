using ArcaneEyeBot.Core.Interfaces;
using RaspberryCam;
using System;
using System.Threading.Tasks;

namespace ArcaneEyeBot.Core.PhotoMakers
{
    public class RaspberryCamPhotoMaker : IPhotoMaker
    {
        public async Task<string> MakePhoto()
        {
            var filePath = $"{Guid.NewGuid()}.jpg";
            var cameras = Cameras.DeclareDevice()
                .Named("Camera 1")
                .WithDevicePath("/dev/video0")
                .Memorize();

            var camera = cameras.Get("Camera 1");
            var pictureSize = new PictureSize(1280, 720);

            camera.SavePicture(pictureSize, filePath, 0);

            return filePath;
        }
    }
}
