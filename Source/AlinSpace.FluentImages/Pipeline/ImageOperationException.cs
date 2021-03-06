using System;

namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Image operation exception.
    /// </summary>
    public class ImageOperationException : Exception
    {
        /// <summary>
        /// Image operation that caused the exception.
        /// </summary>
        public string OperationName { get; }
    
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="operationName">Image operation name that failed.</param>
        /// <param name="innerException">Optional inner exception.</param>
        public ImageOperationException(
            string operationName, 
            Exception innerException = null) 
            : base($"Exception in image operation '{operationName}'.", innerException)
        {
            OperationName = operationName;
        }
    }
}
