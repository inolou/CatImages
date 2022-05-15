using CatImages.Data;
using NUnit.Framework;

namespace CatImages.Tests
{
    public class ImageServiceTests
    {
        private IImagesService imagesService;
        [SetUp]
        public void Setup()
        {
            imagesService = new ImagesService();
        }

        [Test]
        public async Task GetImages_Success()
        {
            // arrange

            // act
            var images = await imagesService.GetImages();

            // assert
            Assert.That(images, Is.Not.Null);
            Assert.That(images[0].Id, Is.Not.Null);
            Assert.That(images[0].Url, Is.Not.Null);
        }
    }
}