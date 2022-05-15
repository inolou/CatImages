using CatImages.Models;
using System.Text;

namespace CatImages.Data
{
    public class FavouritesService : IFavouritesService
    {
        public async Task<FavouritesResponse> AddFavouriteImage(string imageId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.thecatapi.com/v1/");
            client.DefaultRequestHeaders.Add("x-api-key", "01fa68d8-0262-47b2-8a2d-f0a532917ce0");
            var content = new StringContent($"{{\"image_id\": \"{imageId}\"}}", Encoding.UTF8, "application/json");
            var response = await client.PostAsync(client.BaseAddress.AbsoluteUri + "favourites", content);
            response.EnsureSuccessStatusCode();
            var favouriteImageData = await response.Content.ReadFromJsonAsync<FavouritesResponse>();

            return favouriteImageData;
        }

        public async Task<FavouritesRequest[]?> GetFavouriteImages()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.thecatapi.com/v1/");
            client.DefaultRequestHeaders.Add("x-api-key", "01fa68d8-0262-47b2-8a2d-f0a532917ce0");
            var response = await client.GetAsync(client.BaseAddress.AbsoluteUri + "favourites");
            response.EnsureSuccessStatusCode();
            var favouriteImages = await response.Content.ReadFromJsonAsync<FavouritesRequest[]>();

            if (favouriteImages == null)
                return null;

            return favouriteImages;
        }

        public async Task<FavouritesDelete?> DeleteFavouriteImage(int favouriteId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.thecatapi.com/v1/");
            client.DefaultRequestHeaders.Add("x-api-key", "01fa68d8-0262-47b2-8a2d-f0a532917ce0");
            var response = await client.DeleteAsync(client.BaseAddress.AbsoluteUri + $"favourites/{favouriteId}");
            response.EnsureSuccessStatusCode();
            var deleteFavouriteImage = await response.Content.ReadFromJsonAsync<FavouritesDelete>();

            if (deleteFavouriteImage == null)
                return null;

            return deleteFavouriteImage;
        }

    }
}
