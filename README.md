<img src="https://github.com/onixion/FluentImages/blob/main/Assets/Icon.jpg" width="200" height="200">

# FluentImages (Work-in-Progress)
[![NuGet version (FluentImages)](https://img.shields.io/nuget/v/AlinSpace.FluentImages.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentImages/)

A simple fluent library for image processing.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentImages/)

# Examples

 ```csharp
var image = Pipeline
    .New()
    .ResizeTo(400, 300)
    .Execute(new Image(File.ReadAllBytes("Input.jpg")));
```
