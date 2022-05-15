using CatImages.Models;

namespace CatImages.Data
{
    public class ImagesService : IImagesService
    {
        public async Task<Image[]?> GetImages()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.thecatapi.com/v1/");
            client.DefaultRequestHeaders.Add("x-api-key", "01fa68d8-0262-47b2-8a2d-f0a532917ce0");
            var response = await client.GetAsync(client.BaseAddress.AbsoluteUri + "images/search");
            response.EnsureSuccessStatusCode();
            var images = await response.Content.ReadFromJsonAsync<Image[]>();

            if (images == null)
                return null;

            return images;
        }
    }
}