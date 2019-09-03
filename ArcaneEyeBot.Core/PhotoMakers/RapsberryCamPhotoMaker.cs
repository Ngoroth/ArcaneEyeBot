using ArcaneEyeBot.Core.Interfaces;
using System;
using System.Threading.Tasks;
using RaspberryCam;

namespace ArcaneEyeBot.Core.PhotoMakers
{
    public class RapsberryCamPhotoMaker : IPhotoMaker
    {
        public async Task<string> MakePhoto()
        {
            var filePath = $"{Guid.NewGuid()}.jpg";
            var cameras = Cameras.DeclareDevice()
                .Named("Camera 1").WithDevicePath("/dev/video0")
                .Memorize();

            cameras.Default.SavePicture(new PictureSize(1280, 720), filePath);
            return filePath;
        }
    }
}
