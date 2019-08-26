using ArcaneEyeBot.Core.Interfaces;
using System;

namespace ArcaneEyeBot.Core.PhotoMakers
{
    public class EmguCVPhotoService : IPhotoMaker
    {
        public string MakePhoto()
        {
            var filePath = $"{Guid.NewGuid()}.png";

            return filePath;
        }
    }
}
