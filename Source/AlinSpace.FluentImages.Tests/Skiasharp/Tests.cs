using AlinSpace.FluentImages.SkiaSharp;
using System.IO;
using Xunit;

namespace AlinSpace.FluentImages.Tests.Skiasharp
{
    public class Tests
    {
        [Fact]
        public void ResizeTo_1()
        {
            // Act
            Pipeline
                .New()
                .ResizeTo(400, 300)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test.ResizeTo");

            // Assert
            var image = new Image(File.ReadAllBytes("Test.ResizeTo.jpg"));

            Assert.Equal(400, image.Width);
            Assert.Equal(300, image.Height);
        }

        [Fact]
        public void Flip_1()
        {
            // Act
            Pipeline
                .New()
                .Flip(FlipDirection.Horizontal)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test.Flip.Horizontal");

        }
        [Fact]
        public void Flip_2()
        {
            // Act
            Pipeline
                .New()
                .Flip(FlipDirection.Vertical)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test.Flip.Vertical");
        }

        [Fact]
        public void Flip_3()
        {
            // Act
            Pipeline
                .New()
                .Flip(FlipDirection.Both)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test.Flip.Both");
        }

        [Fact]
        public void RotateInDegrees_1()
        {
            // Act
            Pipeline
                .New()
                .RotateInDegrees(45)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test.RotateInDegrees.45");
        }

        [Fact]
        public void RotateInPercentage_1()
        {
            // Act
            Pipeline
                .New()
                .RotateInPercentage(0.25)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test.RotateInPercentage.0.25");
        }

        [Fact]
        public void RotateInPercentage_2()
        {
            // Act
            Pipeline
                .New()
                .RotateInPercentage(-0.25)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test.RotateInPercentage.-0.25");
        }

        [Fact]
        public void Test()
        {
            // Act
            Pipeline
                .New()
                .ExecuteAndExportToFile(
                    new Image(File.ReadAllBytes(Constants.TestImagePath)),
                    "TestTestTest");
        }
    }
}
