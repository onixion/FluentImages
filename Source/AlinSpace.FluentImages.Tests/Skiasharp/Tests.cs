﻿using AlinSpace.FluentImages.SkiaSharp;
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
        public void TranslateBy_1()
        {
            // Act
            Pipeline
                .New()
                .TranslateBy(20, 20)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test.TranslateBy.20.20");
        }

        [Fact]
        public void TranslateInPercentage_1()
        {
            // Act
            Pipeline
                .New()
                .TranslateInPercentage(0.5, 0.5)
                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
                .ExportToFile("Test.TranslateInPercentage.0.5.0.5");
        }

        //[Fact]
        //public void BlendWith_1()
        //{
        //    // Act
        //    Pipeline
        //        .New()
        //        .BlendWith(() => new Image(File.ReadAllBytes(Constants.TestImagePath)))
        //        .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
        //        .ExportToFile("Test.TranslateInPercentage.0.5.0.5");
        //}

        //[Fact]
        //public void Test()
        //{
        //    var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

        //    // Act
        //    Pipeline
        //        .New()
        //        .TranslateInPercentage(0.01, 0.01)
        //        .ExportToFile(
        //            image,
        //            "Test.000000.NoBl")
        //        //.BlendWith(() => image)
        //        .ExportToFile(
        //            image,
        //            "Test.000000.Bl");
        //}
    }
}
