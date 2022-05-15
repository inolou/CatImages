namespace CatImages.Models
{
    public class FavouritesRequest
    {
            public int Id { get; set; }            
            public Image Image { get; set; }
            public string ImageID { get; set; }
            public string UserID { get; set; }
            public DateTime CreatedAt { get; set; }

       

         }
}
