namespace RecycleCross
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Google.Apis.Services;
    using Google.Apis.Vision.v1;
    using Google.Apis.Vision.v1.Data;

    /// <summary>
    /// Cross-platform API for object classification.
    /// </summary>
    public class ObjectClassification
    {
        /// <summary>
        /// Send a request to the Google Cloud Vision API and get classification tags to classify with.
        /// </summary>
        /// <param name="base64Image">Base64'ed Image as a String</param>
        /// <returns>An enum representation of object type.</returns>
        public static async Task<ObjectType> Classify(string base64Image)
        {
            ObjectType objectType = ObjectType.Error;
            var service = new VisionService(new BaseClientService.Initializer
            {
                ApplicationName = "Greenly",
                ApiKey = "$APIKEY",
            });

            string[] featureTypes = { "LABEL_DETECTION", "LOGO_DETECTION" };
            var request = new AnnotateImageRequest();
            request.Image = new Image();
            request.Image.Content = base64Image;

            request.Features = new List<Feature>();

            foreach (var featureType in featureTypes)
            {
                request.Features.Add(new Feature() { Type = featureType });
            }

            var requests = new BatchAnnotateImagesRequest();
            requests.Requests = new List<AnnotateImageRequest>();
            requests.Requests.Add(request);
            var responseBatchTask = service.Images.Annotate(requests).ExecuteAsync();
            var responseBatch = await responseBatchTask;
            AnnotateImageResponse response = null;
            foreach (var resp in responseBatch.Responses)
            {
                response = resp;
            }

            if (response.LogoAnnotations != null)
            {
                foreach (var logoAnnotation in response.LogoAnnotations)
                {
                    string logoDescription = logoAnnotation.Description.ToLower();
                    if (Classifiers.Blue.Contains(logoDescription))
                    {
                        objectType = ObjectType.Blue;
                    }

                    if (Classifiers.Green.Contains(logoDescription))
                    {
                        objectType = ObjectType.Compost;
                    }

                    if (Classifiers.Grey.Contains(logoDescription))
                    {
                        objectType = ObjectType.Grey;
                    }
                }
            }

            if (response.LabelAnnotations != null)
            {
                foreach (var labelAnnotation in response.LabelAnnotations)
                {
                    if (labelAnnotation.Score > .5)
                    {
                        string labelDescription = labelAnnotation.Description.ToLower();
                        if (Classifiers.Blue.Contains(labelDescription))
                        {
                            objectType = ObjectType.Blue;
                        }

                        if (Classifiers.Green.Contains(labelDescription))
                        {
                            objectType = ObjectType.Compost;
                        }

                        if (Classifiers.Grey.Contains(labelDescription))
                        {
                            objectType = ObjectType.Grey;
                        }
                    }
                }
            }

            return objectType;
        }
    }
}
