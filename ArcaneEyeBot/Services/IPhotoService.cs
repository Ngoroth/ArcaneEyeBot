namespace ArcaneEyeBot.Services
{
    public interface IPhotoService
    {
        string MakePhoto();

        void DeletePhoto(string filePath);
    }
}
