namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Pipeline stage function.
    /// </summary>
    /// <param name="inputImage">Input image.</param>
    /// <returns>Output image.</returns>
    public delegate IImage PipelineStageFunction(IImage inputImage);
}
