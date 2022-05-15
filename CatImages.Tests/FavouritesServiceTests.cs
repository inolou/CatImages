using CatImages.Data;
using NUnit.Framework;

namespace CatImages.Tests
{
    public class FavouritesServiceTests
    {
        private IFavouritesService favouritesService;
        private IImagesService imagesService;
        [SetUp]
        public void Setup()
        {
            favouritesService = new FavouritesService();
            imagesService = new ImagesService();
        }

        [Test]
        public async Task GetFavouriteImages_Success()
        {
            // arrange

            // act
            var favouriteImages = await favouritesService.GetFavouriteImages();

            // assert
            Assert.That(favouriteImages, Is.Not.Null);
            Assert.That(favouriteImages[0].Image, Is.Not.Null);
            Assert.That(favouriteImages[0].Image.Url, Is.Not.Null);
        }
        [Test]
        public async Task DeleteFavouriteImages_Success()
        {
            // arrange
            var testFavouriteImage = await favouritesService.AddFavouriteImage("bo6");

            // act
            var favouriteImages = await favouritesService.DeleteFavouriteImage(testFavouriteImage.Id);

            // assert
            Assert.That(favouriteImages, Is.Not.Null);
            Assert.That(favouriteImages.Message, Is.EqualTo("SUCCESS"));

        }
        [Test]
        public async Task AddFavouriteImage_Success()
        {
            //arrange
            var getImage = await imagesService.GetImages();

            // act
            var saveImage = await favouritesService.AddFavouriteImage(getImage[0].Id);

            // assert
            Assert.That(saveImage, Is.Not.Null);
            Assert.That(saveImage.Message, Is.EqualTo("SUCCESS"));
        }
    }
}