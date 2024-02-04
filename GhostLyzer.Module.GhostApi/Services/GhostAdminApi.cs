using GhostLyzer.Module.GhostApi.Enums;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;

namespace GhostLyzer.Module.GhostApi.Services
{
    public partial class GhostAdminAPI : GhostAPI
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:GhostLyzer.Module.GhostApi.Services.GhostAdminAPI"/> class.
        /// </summary>
        /// <param name="host">The Host for which to access the Admin API.</param>
        /// <param name="adminApiKey">Admin API key.</param>
        public GhostAdminAPI(string host, string adminApiKey, ExceptionLevel exceptionLevel = ExceptionLevel.All, string baseUrl = "/ghost/api/admin/", string minimumVersion = null)
            : base(host, adminApiKey, exceptionLevel, baseUrl, APIType.Admin, minimumVersion)
        {
            var adminKeyParts = adminApiKey.Split(':');

            if (adminKeyParts.Length != 2)
            {
                var exception = new ArgumentException("The Admin API Key should consist of an ID and Secret, separated by a colon.");
                LastException = exception;
                throw exception;
            }

            var id = adminKeyParts[0];
            var secret = adminKeyParts[1];

            key = GenerateToken(id, secret);
            VerifyToken(key, secret);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GhostSharp.GhostAdminAPI"/> class without auth.
        /// This is only useful if auth is not required, which is only the /site endpoint.
        /// </summary>
        /// <param name="host">The Host for which to access the Admin API.</param>
        public GhostAdminAPI(string host, ExceptionLevel exceptionLevel = ExceptionLevel.All, string baseUrl = "/ghost/api/content/", string minimumVersion = null)
            : base(host, exceptionLevel, baseUrl, APIType.Admin, minimumVersion)
        {
        }

        /// <summary>
        /// Generates a JWT token with the given ID and secret.
        /// </summary>
        /// <param name="id">The ID to include in the JWT token.</param>
        /// <param name="secret">The secret to use for signing the JWT token.</param>
        /// <returns>A JWT token.</returns>
        private string GenerateToken(string id, string secret)
        {
            var unixEpochInSeconds = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

            return new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm())
                                   .WithSecret(Convert.FromHexString(secret))
                                   .AddHeader(HeaderName.KeyId, id)
                                   .AddHeader(HeaderName.Type, "JWT")
                                   .AddClaim("exp", unixEpochInSeconds + 300)
                                   .AddClaim("iat", unixEpochInSeconds)
                                   .AddClaim("aud", "/admin/")
                                   .Encode();
        }

        /// <summary>
        /// Verifies the given JWT token with the given secret.
        /// </summary>
        /// <param name="token">The JWT token to verify.</param>
        /// <param name="secret">The secret to use for verifying the JWT token.</param>
        /// <exception cref="TokenExpiredException">Thrown when the token has expired.</exception>
        /// <exception cref="SignatureVerificationException">Thrown when the token has an invalid signature.</exception>
        private void VerifyToken(string token, string secret)
        {
            try
            {
                new JwtBuilder()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(Convert.FromHexString(secret))
                    .MustVerifySignature()
                    .Decode(token);
            }
            catch (TokenExpiredException)
            {
                throw new Exception("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                throw new Exception("Token has invalid signature");
            }
        }
    }
}
