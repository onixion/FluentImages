namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Quality.
    /// </summary>
    /// <remarks>
    /// Maybe remove this. It is hard to map "Moderate" to some values.
    /// Makes no sense like this. Maybe just always do operations in the 
    /// best quality. Export quality should be changeable, because of size.
    /// </remarks>
    public enum Quality
    {
        /// <summary>
        /// Best quality.
        /// </summary>
        Best,

        /// <summary>
        /// Moderate,
        /// </summary>
        //Moderate,

        /// <summary>
        ///  Lowest quality.
        /// </summary>
        //Lowest,
    }
}
