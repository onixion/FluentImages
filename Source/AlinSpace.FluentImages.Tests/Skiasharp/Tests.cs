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
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .ResizeTo(400, 300);

            // Act.
            var newImage = pipeline.Execute(image);

            // Assert
            Assert.Equal(400, newImage.Width);
            Assert.Equal(300, newImage.Height);

            // Export
            newImage.ExportToFile("Tests.SkiaSharp.ResizeTo_1.jpg");
        }

        [Fact]
        public void Transform_Flip_Both()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .Flip(FlipDirection.Both);

            // Act.
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile("Tests.SkiaSharp.Transform_Flip_Both.jpg");
        }


        [Fact]
        public void Transform_Flip_Horizontal()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .Flip(FlipDirection.Horizontal);

            // Act.
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile("Tests.SkiaSharp.Transform_Flip_Horizontal.jpg");
        }

        [Fact]
        public void Transform_Flip_Vertical()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .Flip(FlipDirection.Vertical);

            // Act.
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile("Tests.SkiaSharp.Transform_Flip_Vertical.jpg");
        }

        [Fact]
        public void Transform_MapTo_1()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .MapTo(new Rectangle(200, 200, 400, 400));

            // Act.
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile("Tests.SkiaSharp.Transform_MapTo_1.jpg");
        }

        [Fact]
        public void Transform_MapTo_2()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .MapTo(new Rectangle(0, 500, 1920, 1080));

            // Act.
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile("Tests.SkiaSharp.Transform_MapTo_2.jpg");
        }

        [Fact]
        public void Transform_RotateInDegrees_1()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .RotateInDegrees(45.0, 0, 0);

            // Act.
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile("Tests.SkiaSharp.Transform_RotateInDegrees_1.jpg");
        }

        [Fact]
        public void Transform_RotateInDegrees_2()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .RotateInDegrees(45.0, 100, 100);

            // Act.
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile("Tests.SkiaSharp.Transform_RotateInDegrees_2.jpg");
        }

        [Fact]
        public void Transform_RotateInDegrees_3()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .RotateInDegrees(45.0);

            // Act.
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile("Tests.SkiaSharp.Transform_RotateInDegrees_3.jpg");
        }
    }
}
