using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Exceptions;
using GhostLyzer.Module.GhostApi.QueryParams;
using GhostLyzer.Module.GhostApi.Services;

namespace GhostLyzer.Module.GhostApi.Tests.ContentApi.IntegrationTests
{
    [TestFixture]
    public class GetAuthorIntegrationTests : TestBase
    {
        private const int MINIMUM_POST_COUNT_THRESHHOLD = 100;

        private GhostContentAPI auth;

        [SetUp]
        public void SetUp()
        {
            auth = new GhostContentAPI(Host, ValidContentApiKey);
        }

        [Test]
        public void GetAuthorById_ReturnsMatchingAuthor()
        {
            var author = auth.GetAuthorById(ValidAuthor1Id);

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.Not.Null);
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
            Assert.That(author.Bio, Is.Not.Null);

            Assert.That(author.Count, Is.Null);
            Assert.That(author.Email, Is.Null);

            // Not sure why some of these don't return values.. or what they even mean (tour?)
            Assert.That(author.Accessibility, Is.Null);
            Assert.That(author.Status, Is.Null);
            Assert.That(author.Tour, Is.Null);
            Assert.That(author.LastSeen, Is.Null);
            Assert.That(author.Roles, Is.Null);
        }

        [Test]
        public async Task GetAuthorById_ReturnsMatchingAuthor_Async()
        {
            var author = await auth.GetAuthorByIdAsync(ValidAuthor1Id);

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.Not.Null);
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
            Assert.That(author.Bio, Is.Not.Null);

            Assert.That(author.Count, Is.Null);
            Assert.That(author.Email, Is.Null);

            // Not sure why some of these don't return values.. or what they even mean (tour?)
            Assert.That(author.Accessibility, Is.Null);
            Assert.That(author.Status, Is.Null);
            Assert.That(author.Tour, Is.Null);
            Assert.That(author.LastSeen, Is.Null);
            Assert.That(author.Roles, Is.Null);
        }


        [Test]
        public void GetAuthorById_ReturnsPostCount_WhenIncludingCountPosts()
        {
            var author = auth.GetAuthorById(ValidAuthor1Id, new AuthorQueryParams { IncludePostCount = true });

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
            Assert.That(author.Bio, Is.Not.Null);
            Assert.That(author.Count.Posts, Is.GreaterThan(MINIMUM_POST_COUNT_THRESHHOLD));
        }

        [Test]
        public async Task GetAuthorById_ReturnsPostCount_WhenIncludingCountPosts_Async()
        {
            var author = await auth.GetAuthorByIdAsync(ValidAuthor1Id, new AuthorQueryParams { IncludePostCount = true });

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
            Assert.That(author.Bio, Is.Not.Null);
            Assert.That(author.Count.Posts, Is.GreaterThan(MINIMUM_POST_COUNT_THRESHHOLD));
        }

        [Test]
        public void GetAuthorById_ReturnsLimitedFields_WhenFieldsSpecified_ForIndividualRequest()
        {
            var author = auth.GetAuthorById(ValidAuthor1Id, new AuthorQueryParams { Fields = AuthorFields.Id | AuthorFields.Slug });

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.Null);
            Assert.That(author.Url, Is.Null);
            Assert.That(author.Bio, Is.Null);
            Assert.That(author.Count, Is.Null);
        }

        [Test]
        public async Task GetAuthorById_ReturnsLimitedFields_WhenFieldsSpecified_ForIndividualRequest_Async()
        {
            var author = await auth.GetAuthorByIdAsync(ValidAuthor1Id, new AuthorQueryParams { Fields = AuthorFields.Id | AuthorFields.Slug });

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.Null);
            Assert.That(author.Url, Is.Null);
            Assert.That(author.Bio, Is.Null);
            Assert.That(author.Count, Is.Null);
        }

        [Test]
        public void GetAuthorBySlug_ReturnsMatchingAuthor()
        {
            var author = auth.GetAuthorBySlug(ValidAuthor1Slug);

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
            Assert.That(author.Bio, Is.Not.Null);
            Assert.That(author.Count, Is.Null);
        }

        [Test]
        public async Task GetAuthorBySlug_ReturnsMatchingAuthor_Async()
        {
            var author = await auth.GetAuthorBySlugAsync(ValidAuthor1Slug);

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
            Assert.That(author.Bio, Is.Not.Null);
            Assert.That(author.Count, Is.Null);
        }

        [Test]
        public void GetAuthorBySlug_ReturnsPostCount_WhenIncludingCountPosts()
        {
            var author = auth.GetAuthorBySlug(ValidAuthor1Slug, new AuthorQueryParams { IncludePostCount = true });

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
            Assert.That(author.Bio, Is.Not.Null);
            Assert.That(author.Count.Posts, Is.GreaterThan(MINIMUM_POST_COUNT_THRESHHOLD));
        }

        [Test]
        public async Task GetAuthorBySlug_ReturnsPostCount_WhenIncludingCountPosts_Async()
        {
            var author = await auth.GetAuthorBySlugAsync(ValidAuthor1Slug, new AuthorQueryParams { IncludePostCount = true });

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
            Assert.That(author.Bio, Is.Not.Null);
            Assert.That(author.Count.Posts, Is.GreaterThan(MINIMUM_POST_COUNT_THRESHHOLD));
        }

        [Test]
        public void GetAuthorBySlug_ReturnsLimitedFields_WhenFieldsSpecified_ForIndividualRequest()
        {
            var author = auth.GetAuthorBySlug(ValidAuthor1Slug, new AuthorQueryParams { Fields = AuthorFields.Id | AuthorFields.Slug });

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.Null);
            Assert.That(author.Url, Is.Null);
            Assert.That(author.Bio, Is.Null);
            Assert.That(author.Count, Is.Null);
        }

        [Test]
        public async Task GetAuthorBySlug_ReturnsLimitedFields_WhenFieldsSpecified_ForIndividualRequest_Async()
        {
            var author = await auth.GetAuthorBySlugAsync(ValidAuthor1Slug, new AuthorQueryParams { Fields = AuthorFields.Id | AuthorFields.Slug });

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.Null);
            Assert.That(author.Url, Is.Null);
            Assert.That(author.Bio, Is.Null);
            Assert.That(author.Count, Is.Null);
        }

        [Test]
        public void GetAuthorBySlug_Throws_WhenAuthorHasNoPublishedPosts()
        {
            var ex = Assert.Throws<GhostApiException>(() => auth.GetAuthorBySlug(ValidAuthorWithNoPublishedPostsSlug));

            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read author."));
        }

        [Test]
        public async Task GetAuthorBySlug_Throws_WhenAuthorHasNoPublishedPosts_Async()
        {
            var ex = Assert.ThrowsAsync<GhostApiException>(() => auth.GetAuthorBySlugAsync(ValidAuthorWithNoPublishedPostsSlug));

            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read author."));
        }

        [Test]
        public void GetAuthors_ReturnsLimitedAuthors_WhenLimitSpecified()
        {
            var authorResponse = auth.GetAuthors(new AuthorQueryParams { Limit = 1, Fields = AuthorFields.Id });

            Assert.That(authorResponse.Authors.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetAuthors_ReturnsLimitedAuthors_WhenLimitSpecified_Async()
        {
            var authorResponse = await auth.GetAuthorsAsync(new AuthorQueryParams { Limit = 1, Fields = AuthorFields.Id });

            Assert.That(authorResponse.Authors.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetAuthors_ReturnsLimitedFields_WhenFieldsSpecified()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var author = auth.GetAuthors(new AuthorQueryParams { Limit = 1, Fields = AuthorFields.Id }).Authors[0];

            Assert.That(author.Bio, Is.Null);
            Assert.That(author.Count, Is.Null);
            Assert.That(author.CoverImage, Is.Null);
            Assert.That(author.Facebook, Is.Null);
            Assert.That(author.Location, Is.Null);
            Assert.That(author.MetaDescription, Is.Null);
            Assert.That(author.MetaTitle, Is.Null);
            Assert.That(author.Name, Is.Null);
            Assert.That(author.ProfileImage, Is.Null);
            Assert.That(author.Slug, Is.Null);
            Assert.That(author.Twitter, Is.Null);
            Assert.That(author.Website, Is.Null);
            Assert.That(author.Url, Is.Null);

            Assert.That(author.Id, Is.Not.Null);
        }

        [Test]
        public async Task GetAuthors_ReturnsLimitedFields_WhenFieldsSpecified_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var authorResponse = await auth.GetAuthorsAsync(new AuthorQueryParams { Limit = 1, Fields = AuthorFields.Id });
            var author = authorResponse.Authors[0];

            Assert.That(author.Bio, Is.Null);
            Assert.That(author.Count, Is.Null);
            Assert.That(author.CoverImage, Is.Null);
            Assert.That(author.Facebook, Is.Null);
            Assert.That(author.Location, Is.Null);
            Assert.That(author.MetaDescription, Is.Null);
            Assert.That(author.MetaTitle, Is.Null);
            Assert.That(author.Name, Is.Null);
            Assert.That(author.ProfileImage, Is.Null);
            Assert.That(author.Slug, Is.Null);
            Assert.That(author.Twitter, Is.Null);
            Assert.That(author.Website, Is.Null);
            Assert.That(author.Url, Is.Null);

            Assert.That(author.Id, Is.Not.Null);
        }

        [Test]
        public void GetAuthors_ReturnsPostCount_WhenIncludingCountPosts()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var author = auth.GetAuthors(new AuthorQueryParams { Limit = 1, IncludePostCount = true }).Authors[0];

            Assert.That(author.Count.Posts, Is.Not.Null);
        }

        [Test]
        public async Task GetAuthors_ReturnsPostCount_WhenIncludingCountPosts_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var authorResponse = await auth.GetAuthorsAsync(new AuthorQueryParams { Limit = 1, IncludePostCount = true });
            var author = authorResponse.Authors[0];

            Assert.That(author.Count.Posts, Is.Not.Null);
        }

        [Test]
        public void GetAuthors_ReturnsAllAuthors_WhenNoLimitIsTrue()
        {
            var authorResponse = auth.GetAuthors(new AuthorQueryParams { Limit = 1, NoLimit = true, Fields = AuthorFields.Id });

            Assert.That(authorResponse.Authors.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public async Task GetAuthors_ReturnsAllAuthors_WhenNoLimitIsTrue_Async()
        {
            var authorResponse = await auth.GetAuthorsAsync(new AuthorQueryParams { Limit = 1, NoLimit = true, Fields = AuthorFields.Id });

            Assert.That(authorResponse.Authors.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetAuthors_ReturnsExpectedAuthor_WhenOrderingByField()
        {
            var author = auth.GetAuthors(new AuthorQueryParams { Limit = 1, Order = new List<Tuple<AuthorFields, OrderDirection>> { Tuple.Create(AuthorFields.Slug, OrderDirection.desc) } }).Authors[0];

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
        }

        [Test]
        public async Task GetAuthors_ReturnsExpectedAuthor_WhenOrderingByField_Async()
        {
            var authorResponse = await auth.GetAuthorsAsync(new AuthorQueryParams { Limit = 1, Order = new List<Tuple<AuthorFields, OrderDirection>> { Tuple.Create(AuthorFields.Slug, OrderDirection.desc) } });
            var author = authorResponse.Authors[0];

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
        }

        [Test]
        public void GetAuthors_ReturnsExpectedAuthor_WhenGettingSecondPage()
        {
            var author = auth.GetAuthors(new AuthorQueryParams { Limit = 1, Page = 1, Order = new List<Tuple<AuthorFields, OrderDirection>> { Tuple.Create(AuthorFields.Slug, OrderDirection.asc) } }).Authors[0];

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
        }

        [Test]
        public async Task GetAuthors_ReturnsExpectedAuthor_WhenGettingSecondPage_Async()
        {
            var authorResponse = await auth.GetAuthorsAsync(new AuthorQueryParams { Limit = 1, Page = 1, Order = new List<Tuple<AuthorFields, OrderDirection>> { Tuple.Create(AuthorFields.Slug, OrderDirection.asc) } });
            var author = authorResponse.Authors[0];

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
        }

        [Test]
        public void GetAuthors_ReturnsExpectedAuthors_WhenApplyingFilter()
        {
            var authorResponse = auth.GetAuthors(new AuthorQueryParams { Filter = "slug:[christian]" });

            Assert.That(authorResponse.Authors.Count, Is.EqualTo(1));

            var author = authorResponse.Authors[0];

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
        }

        [Test]
        public async Task GetAuthors_ReturnsExpectedAuthors_WhenApplyingFilter_Async()
        {
            var authorResponse = await auth.GetAuthorsAsync(new AuthorQueryParams { Filter = "slug:[christian]" });

            Assert.That(authorResponse.Authors.Count, Is.EqualTo(1));

            var author = authorResponse.Authors[0];

            Assert.That(author.Id, Is.EqualTo(ValidAuthor1Id));
            Assert.That(author.Slug, Is.EqualTo(ValidAuthor1Slug));
            Assert.That(author.Name, Is.EqualTo(ValidAuthor1Name));
            Assert.That(author.Url, Is.EqualTo(ValidAuthor1Url));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetAuthors_ThrowsException_WhenKeyIsInvalid(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            var ex = Assert.Throws<GhostApiException>(() => auth.GetAuthors());
            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Unknown Content API Key"));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public async Task GetAuthors_ThrowsException_WhenKeyIsInvalid_Async(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            var ex = Assert.ThrowsAsync<GhostApiException>(() => auth.GetAuthorsAsync());
            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Unknown Content API Key"));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetAuthors_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            Assert.That(auth.GetAuthors(), Is.Null);
            Assert.That(auth.LastException, Is.Not.Null);
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public async Task GetAuthors_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed_Async(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            Assert.That(await auth.GetAuthorsAsync(), Is.Null);
            Assert.That(auth.LastException, Is.Not.Null);
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetAuthorById_ThrowsGhostSharpException_WhenIdIsInvalid(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.Throws<GhostApiException>(() => auth.GetAuthorById(InvalidAuthorId));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read author."));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public async Task GetAuthorById_ThrowsGhostSharpException_WhenIdIsInvalid_Async(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.ThrowsAsync<GhostApiException>(() => auth.GetAuthorByIdAsync(InvalidAuthorId));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read author."));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetAuthorById_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            Assert.That(auth.GetAuthorById(InvalidAuthorId), Is.Null);
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public async Task GetAuthorById_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed_Async(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            Assert.That(await auth.GetAuthorByIdAsync(InvalidAuthorId), Is.Null);
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetAuthorBySlug_ThrowsGhostSharpException_WhenSlugIsInvalid(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.Throws<GhostApiException>(() => auth.GetAuthorBySlug(InvalidAuthorSlug));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read author."));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public async Task GetAuthorBySlug_ThrowsGhostSharpException_WhenSlugIsInvalid_Async(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.ThrowsAsync<GhostApiException>(() => auth.GetAuthorBySlugAsync(InvalidAuthorSlug));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read author."));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetAuthorBySlug_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            Assert.That(auth.GetAuthorBySlug(InvalidAuthorSlug), Is.Null);
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public async Task GetAuthorBySlug_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed_Async(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            Assert.That(await auth.GetAuthorBySlugAsync(InvalidAuthorSlug), Is.Null);
        }
    }
}
