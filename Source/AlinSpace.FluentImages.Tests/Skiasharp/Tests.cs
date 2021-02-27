using FluentImages.SkiaSharp;
using System.IO;
using Xunit;

namespace FluentImages.Tests.Skiasharp
{
    public class Tests
    {
        [Fact]
        public void Test()
        {
            // Act
            Pipeline
                .New()
                .ResizeTo(400, 300)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test");

            // Assert
            var image = new Image(File.ReadAllBytes("Test.jpg"));

            Assert.Equal(400, image.Width);
            Assert.Equal(300, image.Height);
        }
    }
}
