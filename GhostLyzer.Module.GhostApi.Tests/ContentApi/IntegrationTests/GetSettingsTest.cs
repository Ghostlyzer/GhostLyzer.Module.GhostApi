using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Exceptions;
using GhostLyzer.Module.GhostApi.Services;

namespace GhostLyzer.Module.GhostApi.Tests.ContentApi.IntegrationTests
{
    [TestFixture]
    public class GetSettingsIntgTests : TestBase
    {
        [Test]
        public void GetSettings_ReturnsSettings_WhenKeyIsValid()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            Assert.That(SiteTitle, Is.EqualTo(auth.GetSettings().Title));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetSettings_ThrowsException_WhenKeyIsInvalid(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            var ex = Assert.Throws<GhostApiException>(() => auth.GetSettings());
            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That("Unknown Content API Key", Is.EqualTo(ex.Errors[0].Message));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetSettings_DoesNotThrow_ReturnsNull_WhenKeyIsInvalid(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            Assert.That(auth.GetSettings(), Is.Null);
            Assert.That(auth.LastException, Is.Not.Null);
        }
    }
}
