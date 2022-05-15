using CatImages.Models;

namespace CatImages.Data
{
    public interface IImagesService
    {
        Task<Image[]?> GetImages();
    }
}