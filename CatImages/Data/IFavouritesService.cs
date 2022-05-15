using CatImages.Models;

namespace CatImages.Data
{
    public interface IFavouritesService
    {
        Task<FavouritesResponse> AddFavouriteImage(string imageId);
        Task<FavouritesDelete?> DeleteFavouriteImage(int favouriteId);
        Task<FavouritesRequest[]?> GetFavouriteImages();
    }
}