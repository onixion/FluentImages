using AlinSpace.FluentImages.Gdi;
using System.IO;
using Xunit;

namespace AlinSpace.FluentImages.Tests.Gdi
{
    public class Tests
    {
        public const string LibraryName = "Gdi";

        [Fact]
        public void ResizeTo_1()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .ResizeTo(400, 400);

            // Act
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile($"{LibraryName}.{nameof(ResizeTo_1)}.jpg");

            // Assert
            Assert.Equal(400, newImage.Width);
            Assert.Equal(400, newImage.Height);
        }

        [Fact]
        public void ResizeTo_2()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .ResizeToHeight(500);

            // Act
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile($"{LibraryName}.{nameof(ResizeTo_2)}.jpg");

            // Assert
            Assert.Equal((int)(500 * image.GetAspectRatio()), newImage.Width);
            Assert.Equal(500, newImage.Height);
        }

        [Fact]
        public void ResizeTo_3()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .ResizeToWidth(500);

            // Act
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile($"{LibraryName}.{nameof(ResizeTo_3)}.jpg");

            // Assert
            Assert.Equal(500, newImage.Width);
            Assert.Equal((int)(500 / image.GetAspectRatio()), newImage.Height);
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
            newImage.ExportToFile($"{LibraryName}.{nameof(Transform_Flip_Both)}.jpg");
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
            newImage.ExportToFile($"{LibraryName}.{nameof(Transform_Flip_Horizontal)}.jpg");
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
            newImage.ExportToFile($"{LibraryName}.{nameof(Transform_Flip_Vertical)}.jpg");
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
            newImage.ExportToFile($"{LibraryName}.{nameof(Transform_MapTo_1)}.jpg");
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
            newImage.ExportToFile($"{LibraryName}.{nameof(Transform_MapTo_2)}.jpg");
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
            newImage.ExportToFile($"{LibraryName}.{nameof(Transform_RotateInDegrees_1)}.jpg");
        }

        [Fact]
        public void Transform_RotateInDegrees_2()
        {
            // Prepare
            var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

            var pipeline = Pipeline
                .New()
                .RotateInDegrees(-45.0, 1920, 0);

            // Act.
            var newImage = pipeline.Execute(image);

            // Export
            newImage.ExportToFile($"{LibraryName}.{nameof(Transform_RotateInDegrees_2)}.jpg");
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
            newImage.ExportToFile($"{LibraryName}.{nameof(Transform_RotateInDegrees_3)}.jpg");
        }
    }
}
