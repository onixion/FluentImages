<img src="https://github.com/onixion/FluentImages/blob/main/Assets/Icon.jpg" width="200" height="200">

# FluentImages
[![NuGet version (FluentImages)](https://img.shields.io/nuget/v/AlinSpace.FluentImages.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentImages/)

A simple fluent library for image processing.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentImages/)

##
Third-Party support

- [AlinSpace.FluentImages.SkiaSharp](https://www.nuget.org/packages/AlinSpace.FluentImages.SkiaSharp/)

## Why?

Image library APIs are always really clunky to use. Often you need to create a lot of classes for simple image
manipulations. And dipose.
This library offers a simple way of defining a set of image operations into a pipeline.

## How does it work?

A image pipeline defines a sequence of image operations.
When the pipeline is configured, images can be passed through the pipeline.

## Example - Resizing

```csharp
// Load image.
var image = new Image(File.ReadAllBytes("Input.jpg"));
 
// Resize image to 400x300 and export it.
Pipeline
    .New()
    .ResizeTo(400, 300)
    .ExportToFile(image, "Output.jpg");
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
        }
    }
}
```

Use the pipeline extension method like this:

```csharp
// Load image.
var image = new Image(File.ReadAllBytes("Input.jpg"));
 
// Resize image to 400x300 and export it.
Pipeline
    .New()
    .MyFunction()
    .ExportToFile(image, "Output.jpg");
```

