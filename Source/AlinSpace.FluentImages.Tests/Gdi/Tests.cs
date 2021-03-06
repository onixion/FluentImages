
//using System.IO;
//using Xunit;

//namespace AlinSpace.FluentImages.Tests.Gdi
//{
//    public class Tests
//    {
//        [Fact]
//        public void ResizeTo_1()
//        {
//            // Act
//            //Pipeline
//            //    .New()
//            //    .ResizeTo(400, 300)
//            //    .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
//            //    .ExportToFile("Tests.Gdi.ResizeTo_1.jpg");

//            // Assert
//            //var image = new Image(File.ReadAllBytes("Tests.SkiaSharp.ResizeTo_1.jpg"));

//            //Assert.Equal(400, image.Width);
//            //Assert.Equal(300, image.Height);
//        }

//        [Fact]
//        public void Flip_1()
//        {
//            // Act
//            Pipeline
//                .New()
//                .Flip(FlipDirection.Horizontal)
//                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
//                .ExportToFile("Tests.Gdi.Flip_1.jpg");
//        }

//        [Fact]
//        public void Flip_2()
//        {
//            // Act
//            Pipeline
//                .New()
//                .Flip(FlipDirection.Vertical)
//                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
//                .ExportToFile("Tests.Gdi.Flip_2.jpg");
//        }

//        [Fact]
//        public void Flip_3()
//        {
//            // Act
//            Pipeline
//                .New()
//                .Flip(FlipDirection.Both)
//                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
//                .ExportToFile("Tests.Gdi.Flip_3.jpg");
//        }

//        [Fact]
//        public void RotateInDegrees_1()
//        {
//            // Act
//            Pipeline
//                .New()
//                .RotateInDegrees(45)
//                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
//                .ExportToFile("Tests.Gdi.RotateInDegrees_1.jpg");
//        }

//        [Fact]
//        public void RotateInPercentage_1()
//        {
//            // Act
//            Pipeline
//                .New()
//                .RotateInPercentage(0.25)
//                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
//                .ExportToFile("Tests.Gdi.RotateInPercentage_1.jpg");
//        }

//        [Fact]
//        public void RotateInPercentage_2()
//        {
//            // Act
//            Pipeline
//                .New()
//                .RotateInPercentage(-0.25)
//                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
//                .ExportToFile("Tests.Gdi.RotateInPercentage_2.jpg");
//        }

//        [Fact]
//        public void MapTo_1()
//        {
//            // Act
//            Pipeline
//                .New()
//                .MapTo(new Rectangle(50, 50, 0, 0))
//                .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
//                .ExportToFile("Tests.Gdi.MapTo_1.jpg");
//        }

//        //[Fact]
//        //public void BlendWith_1()
//        //{
//        //    // Act
//        //    Pipeline
//        //        .New()
//        //        .BlendWith(() => new Image(File.ReadAllBytes(Constants.TestImagePath)))
//        //        .Execute(new Image(File.ReadAllBytes(Constants.TestImagePath)))
//        //        .ExportToFile("Test.TranslateInPercentage.0.5.0.5");
//        //}

//        //[Fact]
//        //public void Test()
//        //{
//        //    var image = new Image(File.ReadAllBytes(Constants.TestImagePath));

//        //    // Act
//        //    Pipeline
//        //        .New()
//        //        .TranslateInPercentage(0.01, 0.01)
//        //        .ExportToFile(
//        //            image,
//        //            "Test.000000.NoBl")
//        //        //.BlendWith(() => image)
//        //        .ExportToFile(
//        //            image,
//        //            "Test.000000.Bl");
//        //}
//    }
//}
