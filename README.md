<img src="https://github.com/onixion/FluentImages/blob/main/Assets/Icon.jpg" width="200" height="200">

# FluentImages
[![NuGet version (FluentImages)](https://img.shields.io/nuget/v/AlinSpace.FluentImages.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentImages/)

A simple fluent library for image processing.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentImages/)

## Supported image libraries

- **SkiaSharp**: [AlinSpace.FluentImages.SkiaSharp](https://www.nuget.org/packages/AlinSpace.FluentImages.SkiaSharp/)
- **System.Drawing**: AlinSpace.FluentImages.Gdi
- **Magick.NET**: AlinSpace.FluentImages.Magick
- **ImageSharp**: AlinSpace.FluentImages.ImageSharp

## Why?

Image library APIs are often really clunky to use. Often you need a lot of setup code to do simple image manipulations.

This library offers a simple way of defining a set of image operations and allows to execute the sequence of operations on
an image. You can execute the same pipeline on different backend libraries (e.g. SkiaSharp, ImageSharp, ...).
The library can easily be extended with new functionality.

## How does it work?

An *image pipeline* defines a sequence of image operations. Each operation is defined as a *pipeline function*.
A pipeline function takes an input image and returns an output image.

When the pipeline is configured, images can be executed on the pipeline.
The pipeline will return a new image when executed.

## Example - Resizing

```csharp
// Import image.
var image = new Image(File.ReadAllBytes("Input.jpg"));
 
// Resize image to 400x300.
var newImage = Pipeline
    .New()
    .ResizeTo(400, 300)
    .Execute(image);
    
// Export image.
newImage.ExportToFile("Output.jpg");
```

## Custom pipeline function

To extend the pipeline with additional functionality, a custom extension class can be created, like this:

 ```csharp
public static class MyPipelineExtensions
{
    public Pipeline MyFunction(Pipeline pipeline)
    {
        pipeline.AddFunction(image => 
        {
            // Modify image.
            return image;
        });
        
        return pipeline;
    }
}
```

Use the pipeline extension method like this:

```csharp
// Load image.
var image = new Image(File.ReadAllBytes("Input.jpg"));
 
// Execute MyFunction on the image and export it.
Pipeline
    .New()
    .MyFunction()
    .ExportToFile(image, "Output.jpg");
```

