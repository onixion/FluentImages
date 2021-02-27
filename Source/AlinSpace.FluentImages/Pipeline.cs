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
        readonly IList<PipelineStageFunction> stageFunctions;

        /// <summary>
        /// Factory method constructor.
        /// </summary>
        /// <param name="stageFunctions">Enumerable of stage functions.</param>
        /// <returns>New instance.</returns>
        public static Pipeline New(IEnumerable<PipelineStageFunction> stageFunctions = null)
        {
            return new Pipeline(stageFunctions);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stageFunctions">Enumerable of stage functions.</param>
        public Pipeline(IEnumerable<PipelineStageFunction> stageFunctions = null)
        {
            this.stageFunctions = stageFunctions?.ToList() ?? new List<PipelineStageFunction>();
        }

        /// <summary>
        /// Clone pipeline.
        /// </summary>
        /// <returns>Cloned pipeline.</returns>
        public Pipeline Clone()
        {
            return new Pipeline(stageFunctions);
        }

        /// <summary>
        /// Add a pipeline stage function.
        /// </summary>
        /// <param name="stageFunction">Stage function.</param>
        /// <returns>Pipeline.</returns>
        public Pipeline AddStage(PipelineStageFunction stageFunction)
        {
            stageFunctions.Add(stageFunction);
            return this;
        }

        /// <summary>
        /// Execute pipeline.
        /// </summary>
        /// <param name="image">Image to push through the pipeline.</param>
        /// <returns>New image created by the pipeline.</returns>
        public IImage Execute(IImage image)
        {
            var currentImage = image;

            foreach(var function in stageFunctions)
            {
                var tempImage = function(currentImage);

                try
                {
                    if (!ReferenceEquals(image, currentImage))
                    {
                        currentImage.Dispose();
                    }
                }
                catch(ImageOperationException e)
                {

                }
                catch(Exception e)
                {

                }

                currentImage = tempImage;
            }

            return currentImage;
        }
    }
}
