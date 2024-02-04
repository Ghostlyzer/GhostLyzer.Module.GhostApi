using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Models;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        /// <summary>
        /// Uploads an image to the site.
        /// </summary>
        /// <param name="image">The image to upload.</param>
        /// <returns>The uploaded image.</returns>
        public Image UploadImage(ImageRequest image)
        {
            var request = PrepareUploadImageRequest(image);
            return Execute<ImageResponse>(request).Images[0];
        }

        /// <summary>
        /// Uploads an image to the site asynchronously.
        /// </summary>
        /// <param name="image">The image to upload.</param>
        /// <returns>The uploaded image.</returns>
        public async Task<Image> UploadImageAsync(ImageRequest image)
        {
            var request = PrepareUploadImageRequest(image);
            var response = await ExecuteAsync<ImageResponse>(request);
            return response.Images[0];
        }

        private static string GetMimeType(ImageType imageType)
        {
            return MimeTypes[imageType];
        }

        /// <summary>
        /// Prepares a RestRequest for uploading an image.
        /// </summary>
        /// <param name="image">The image to upload.</param>
        /// <returns>A RestRequest that can be used to upload an image.</returns>
        private RestRequest PrepareUploadImageRequest(ImageRequest image)
        {
            var request = CreateRequest(Method.Post, "images/upload");

            if (image.FilePath != null)
                request.AddFile(nameof(image.File), image.FilePath, GetMimeType(image.ImageType));
            else
                request.AddFile(nameof(image.File), image.File, image.FileName, GetMimeType(image.ImageType));

            request.AddParameter("purpose", image.Purpose.ToString().ToLower());
            request.AddParameter("ref", image.Reference);

            return request;
        }

        private static readonly Dictionary<ImageType, string> MimeTypes = new Dictionary<ImageType, string>
        {
            { ImageType.GIF, "image/gif" },
            { ImageType.ICO, "image/x-icon" },
            { ImageType.JPEG, "image/jpeg" },
            { ImageType.PNG, "image/png" },
            { ImageType.SVG, "image/svg+xml" },
            { ImageType.Unknown, "application/octet-stream" },
        };
    }
}
