using System.Threading.Tasks;

namespace ArcaneEyeBot.Core.Interfaces
{
    public interface IPhotoMaker
    {
        /// <summary>
        /// Make photo in base directory
        /// </summary>
        /// <returns>Photo filename</returns>
        Task<string> MakePhoto();
    }
}
