using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Models;
using RestSharp;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI
    {
        private static readonly Dictionary<ImageType, string> MimeTypes = new Dictionary<ImageType, string>
        {
            { ImageType.GIF, "image/gif" },
            { ImageType.ICO, "image/x-icon" },
            { ImageType.JPEG, "image/jpeg" },
            { ImageType.PNG, "image/png" },
            { ImageType.SVG, "image/svg+xml" },
            { ImageType.Unknown, "application/octet-stream" },
        };

        /// <summary>
        /// Upload an image to the site
        /// </summary>
        /// <returns>Returns location from which the image can be fetched, and reference string if any.</returns>
        public Image UploadImage(ImageRequest image)
        {
            var request = new RestRequest("images/upload/", Method.Post);

            if (image.FilePath != null)
                request.AddFile(nameof(image.File), image.FilePath, GetMimeType(image.ImageType));
            else
                request.AddFile(nameof(image.File), image.File, image.FileName, GetMimeType(image.ImageType));

            request.AddParameter("purpose", image.Purpose.ToString().ToLower());
            request.AddParameter("ref", image.Reference);

            return Execute<ImageResponse>(request).Images[0];
        }

        private static string GetMimeType(ImageType imageType)
        {
            return MimeTypes[imageType];
        }
    }
}
