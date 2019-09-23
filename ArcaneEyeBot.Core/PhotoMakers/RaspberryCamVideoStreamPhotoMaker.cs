using ArcaneEyeBot.Core.Interfaces;
using RaspberryCam;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ArcaneEyeBot.Core.PhotoMakers
{
    public class RaspberryCamVideoStreamPhotoMaker : IPhotoMaker
    {
        private readonly CamDriver cameraDriver;
        private readonly PictureSize pictureSize = new PictureSize(1280, 720);
        public RaspberryCamVideoStreamPhotoMaker()
        {
            var cameras = Cameras.DeclareDevice()
                .Named("Camera 1")
                .WithDevicePath("/dev/video0")
                .Memorize();

            this.cameraDriver = cameras.Get("Camera 1");

            this.cameraDriver.StartVideoStreaming(this.pictureSize);
        }

        ~RaspberryCamVideoStreamPhotoMaker()
        {
            if (this.cameraDriver.IsVideoStreamOpenned)
            {
                this.cameraDriver.StopVideoStreaming();
            }
        }

        public async Task<string> MakePhoto()
        {
            var filePath = $"{Guid.NewGuid()}.jpg";

            this.cameraDriver.GetVideoFrame();

            var frameBytes = this.cameraDriver.GetVideoFrame();

            File.WriteAllBytes(filePath, frameBytes);

            return filePath;
        }
    }
}
