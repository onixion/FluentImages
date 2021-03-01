<img src="https://github.com/onixion/FluentImages/blob/main/Assets/Icon.jpg" width="200" height="200">

# FluentImages
[![NuGet version (FluentImages)](https://img.shields.io/nuget/v/AlinSpace.FluentImages.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentImages/)

A simple fluent library for image processing.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentImages/)

### Third-Party support

- [AlinSpace.FluentImages.SkiaSharp](https://www.nuget.org/packages/AlinSpace.FluentImages.SkiaSharp/)

# Examples

## Resize

 ```csharp
// Resize image to 400x300 and export it.
Pipeline
    .New()
    .ResizeTo(400, 300)
    .ExportToFile(new Image(File.ReadAllBytes("Input.jpg")), "Output");
```
