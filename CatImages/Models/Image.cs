using Newtonsoft.Json;

namespace CatImages.Models
{
    public class Image
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }        
    }
}
