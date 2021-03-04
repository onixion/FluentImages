using System;
using System.Collections.Generic;
using System.Linq;

namespace AlinSpace.FluentImages
{
    /// <summary>
    /// Image pipeline.
    /// </summary>
    public class Pipeline
    {
        readonly IList<PipelineFunction> functions;

        /// <summary>
        /// Factory method constructor.
        /// </summary>
        /// <param name="functions">Enumerable of pipeline functions.</param>
        /// <returns>New instance.</returns>
        public static Pipeline New(IEnumerable<PipelineFunction> functions = null)
        {
            return new Pipeline(functions);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <remarks>
        /// Copies the functions at the time of running this constructor.
        /// </remarks>
        public static Pipeline New(Pipeline pipeline)
        {
            return new Pipeline(pipeline);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="functions">Enumerable of pipeline functions.</param>
        public Pipeline(IEnumerable<PipelineFunction> functions = null)
        {
            this.functions = functions?.ToList() ?? new List<PipelineFunction>();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pipeline">Pipeline.</param>
        /// <remarks>
        /// Copies the functions at the time of running this constructor.
        /// </remarks>
        public Pipeline(Pipeline pipeline)
        {
            functions = pipeline.functions.ToArray();
        }

        /// <summary>
        /// Clone pipeline.
        /// </summary>
        /// <returns>Cloned pipeline.</returns>
        public Pipeline Clone()
        {
            return new Pipeline(functions);
        }

        /// <summary>
        /// Add a pipeline function.
        /// </summary>
        /// <param name="function">Pipeline function.</param>
        /// <returns>Pipeline.</returns>
        public Pipeline AddFunction(PipelineFunction function)
        {
            if (function == null)
                throw new ArgumentNullException(nameof(function));

            functions.Add(function);
            return this;
        }

        /// <summary>
        /// Execute pipeline.
        /// </summary>
        /// <param name="image">Image to push through the pipeline.</param>
        /// <returns>New image created by the pipeline.</returns>
        public IImage Execute(IImage image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            // Make a copy so we don't alter/dispose the image the user gave us.
            var currentImage = image.Clone();

            foreach(var function in functions)
            {
                try
                {
                    var tempImage = function(currentImage);

                    // If the pipeline function created a new output image,
                    // dispose the input image.
                    if (!ReferenceEquals(tempImage, currentImage))
                    {
                        currentImage.Dispose();
                    }

                    currentImage = tempImage;
                }
                catch(Exception e)
                {
                    // TODO
                    throw;
                }
            }

            return currentImage;
        }
    }
}
