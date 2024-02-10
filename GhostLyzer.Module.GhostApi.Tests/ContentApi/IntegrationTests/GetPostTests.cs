using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Exceptions;
using GhostLyzer.Module.GhostApi.QueryParams;
using GhostLyzer.Module.GhostApi.Services;

namespace GhostLyzer.Module.GhostApi.Tests.ContentApi.IntegrationTests
{
    [TestFixture]
    public class GetPostIntegrationTests : TestBase
    {
        private const int MINIMUM_POST_COUNT_THRESHHOLD = 100;

        private GhostAPI auth;

        [SetUp]
        public void SetUp()
        {
            auth = new GhostContentAPI(Host, ValidContentApiKey);
        }

        [Test]
        public void GetPostById_ReturnsMatchingPost()
        {
            var post = auth.GetPostById(ValidPost1Id);

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.EqualTo(ValidPost1Title));
            Assert.That(post.Url, Is.EqualTo(ValidPost1Url));
            Assert.That(post.CodeInjectionHead, Is.EqualTo(ValidPost1CodeInjectionHeader));
            Assert.That(post.CodeInjectionFoot, Is.EqualTo(ValidPost1CodeInjectionFooter));

            Assert.That(post.Uuid, Is.Not.Null);
            Assert.That(post.Html, Is.Not.Null);
            Assert.That(post.CommentId, Is.Not.Null);
            Assert.That(post.FeatureImage, Is.Not.Null);
            Assert.That(post.MetaDescription, Is.Not.Null);
            Assert.That(post.CreatedAt, Is.Not.Null);
            Assert.That(post.UpdatedAt, Is.Not.Null);
            Assert.That(post.PublishedAt, Is.Not.Null);
            Assert.That(post.CustomExcerpt, Is.Not.Null);
            Assert.That(post.OgDescription, Is.Not.Null);
            Assert.That(post.TwitterDescription, Is.Not.Null);
            Assert.That(post.Url, Is.Not.Null);
            Assert.That(post.Excerpt, Is.Not.Null);
            Assert.That(post.MetaTitle, Is.Not.Null);
            Assert.That(post.OgImage, Is.Not.Null);
            Assert.That(post.OgTitle, Is.Not.Null);
            Assert.That(post.TwitterImage, Is.Not.Null);
            Assert.That(post.TwitterTitle, Is.Not.Null);
            Assert.That(post.CustomTemplate, Is.Not.Null);
            Assert.That(post.PlainText, Is.Not.Null);

            Assert.That(post.PrimaryAuthor, Is.Null);
            Assert.That(post.PrimaryTag, Is.Null);
            Assert.That(post.Authors, Is.Null);
            Assert.That(post.Tags, Is.Null);
            Assert.That(post.MobileDoc, Is.Null);
        }

        [Test]
        public void GetPostById_ReturnsAuthors_WhenIncludingAuthors()
        {
            var post = auth.GetPostById(ValidPost1Id, new PostQueryParams { IncludeAuthors = true });

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.EqualTo(ValidPost1Title));
            Assert.That(post.Url, Is.EqualTo(ValidPost1Url));

            Assert.That(post.Authors, Is.Not.Null);
            Assert.That(post.PrimaryAuthor, Is.Not.Null);
            Assert.That(post.Authors[0].Id, Is.EqualTo(ValidPost1Author));
            Assert.That(post.PrimaryAuthor.Id, Is.EqualTo(ValidPost1Author));

            Assert.That(post.Tags, Is.Null);
            Assert.That(post.PrimaryTag, Is.Null);
        }

        [Test]
        public void GetPostById_ReturnsTags_WhenIncludingTags()
        {
            var post = auth.GetPostById(ValidPost1Id, new PostQueryParams { IncludeTags = true });

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.EqualTo(ValidPost1Title));
            Assert.That(post.Url, Is.EqualTo(ValidPost1Url));

            Assert.That(post.Tags, Is.Not.Null);
            Assert.That(post.PrimaryTag, Is.Not.Null);
            Assert.That(post.Tags.Select(x => x.Id).ToList(), Does.Contain(ValidPost1PrimaryTag));
            Assert.That(post.PrimaryTag.Id, Is.EqualTo(ValidPost1PrimaryTag));

            Assert.That(post.Authors, Is.Null);
            Assert.That(post.PrimaryAuthor, Is.Null);
        }

        [Test]
        public void GetPostById_ReturnsAuthorsAndTags_WhenIncludingAuthorsAndTags()
        {
            var post = auth.GetPostById(ValidPost1Id, new PostQueryParams { IncludeAuthors = true, IncludeTags = true });

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.EqualTo(ValidPost1Title));
            Assert.That(post.Url, Is.EqualTo(ValidPost1Url));

            Assert.That(post.Tags, Is.Not.Null);
            Assert.That(post.PrimaryTag, Is.Not.Null);
            Assert.That(post.Tags.Select(x => x.Id).ToList(), Does.Contain(ValidPost1PrimaryTag));
            Assert.That(post.PrimaryTag.Id, Is.EqualTo(ValidPost1PrimaryTag));

            Assert.That(post.Authors, Is.Not.Null);
            Assert.That(post.PrimaryAuthor, Is.Not.Null);
            Assert.That(post.Authors[0].Id, Is.EqualTo(ValidPost1Author));
            Assert.That(post.PrimaryAuthor.Id, Is.EqualTo(ValidPost1Author));
        }

        [Test]
        public void GetPostById_ReturnsLimitedFields_WhenFieldsSpecified()
        {
            var post = auth.GetPostById(ValidPost1Id, new PostQueryParams { Fields = PostFields.Id | PostFields.Slug });

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.Null);
            Assert.That(post.Url, Is.Null);
        }

        [Test]
        public void GetPostBySlug_ReturnsMatchingPost()
        {
            var post = auth.GetPostBySlug(ValidPost1Slug);

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.EqualTo(ValidPost1Title));
            Assert.That(post.Url, Is.EqualTo(ValidPost1Url));
            Assert.That(post.CodeInjectionHead, Is.EqualTo(ValidPost1CodeInjectionHeader));
            Assert.That(post.CodeInjectionFoot, Is.EqualTo(ValidPost1CodeInjectionFooter));

            Assert.That(post.Uuid, Is.Not.Null);
            Assert.That(post.Html, Is.Not.Null);
            Assert.That(post.CommentId, Is.Not.Null);
            Assert.That(post.FeatureImage, Is.Not.Null);
            Assert.That(post.MetaDescription, Is.Not.Null);
            Assert.That(post.CreatedAt, Is.Not.Null);
            Assert.That(post.UpdatedAt, Is.Not.Null);
            Assert.That(post.PublishedAt, Is.Not.Null);
            Assert.That(post.CustomExcerpt, Is.Not.Null);
            Assert.That(post.OgDescription, Is.Not.Null);
            Assert.That(post.TwitterDescription, Is.Not.Null);
            Assert.That(post.Url, Is.Not.Null);
            Assert.That(post.Excerpt, Is.Not.Null);

            Assert.That(post.MetaTitle, Is.Not.Null);
            Assert.That(post.OgImage, Is.Not.Null);
            Assert.That(post.OgTitle, Is.Not.Null);
            Assert.That(post.TwitterImage, Is.Not.Null);
            Assert.That(post.TwitterTitle, Is.Not.Null);
            Assert.That(post.CustomTemplate, Is.Not.Null);
            Assert.That(post.PrimaryAuthor, Is.Null);
            Assert.That(post.PrimaryTag, Is.Null);
            Assert.That(post.Authors, Is.Null);
            Assert.That(post.Tags, Is.Null);
        }

        [Test]
        public void GetPostBySlug_ReturnsAuthors_WhenIncludingAuthors()
        {
            var post = auth.GetPostBySlug(ValidPost1Slug, new PostQueryParams { IncludeAuthors = true });

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.EqualTo(ValidPost1Title));
            Assert.That(post.Url, Is.EqualTo(ValidPost1Url));

            Assert.That(post.Authors, Is.Not.Null);
            Assert.That(post.PrimaryAuthor, Is.Not.Null);
            Assert.That(post.Authors[0].Id, Is.EqualTo(ValidPost1Author));
            Assert.That(post.PrimaryAuthor.Id, Is.EqualTo(ValidPost1Author));

            Assert.That(post.Tags, Is.Null);
            Assert.That(post.PrimaryTag, Is.Null);
        }

        [Test]
        public void GetPostBySlug_ReturnsTags_WhenIncludingTags()
        {
            var post = auth.GetPostBySlug(ValidPost1Slug, new PostQueryParams { IncludeTags = true });

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.EqualTo(ValidPost1Title));
            Assert.That(post.Url, Is.EqualTo(ValidPost1Url));

            Assert.That(post.Tags, Is.Not.Null);
            Assert.That(post.PrimaryTag, Is.Not.Null);
            Assert.That(post.Tags.Select(x => x.Id).ToList(), Does.Contain(ValidPost1PrimaryTag));
            Assert.That(post.PrimaryTag.Id, Is.EqualTo(ValidPost1PrimaryTag));

            Assert.That(post.Authors, Is.Null);
            Assert.That(post.PrimaryAuthor, Is.Null);
        }

        [Test]
        public void GetPostBySlug_ReturnsAuthorsAndTags_WhenIncludingAuthorsAndTags()
        {
            var post = auth.GetPostBySlug(ValidPost1Slug, new PostQueryParams { IncludeAuthors = true, IncludeTags = true });

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.EqualTo(ValidPost1Title));
            Assert.That(post.Url, Is.EqualTo(ValidPost1Url));

            Assert.That(post.Tags, Is.Not.Null);
            Assert.That(post.PrimaryTag, Is.Not.Null);
            Assert.That(post.Tags.Select(x => x.Id).ToList(), Does.Contain(ValidPost1PrimaryTag));
            Assert.That(post.PrimaryTag.Id, Is.EqualTo(ValidPost1PrimaryTag));

            Assert.That(post.Authors, Is.Not.Null);
            Assert.That(post.PrimaryAuthor, Is.Not.Null);
            Assert.That(post.Authors[0].Id, Is.EqualTo(ValidPost1Author));
            Assert.That(post.PrimaryAuthor.Id, Is.EqualTo(ValidPost1Author));
        }

        [Test]
        public void GetPostBySlug_ReturnsLimitedFields_WhenFieldsSpecified()
        {
            var post = auth.GetPostBySlug(ValidPost1Slug, new PostQueryParams { Fields = PostFields.Id | PostFields.Slug });

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.Null);
            Assert.That(post.Url, Is.Null);
        }

        [Test]
        public void GetPosts_ReturnsLimitedPosts_WhenLimitSpecified()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var postResponse = auth.GetPosts(new PostQueryParams { Limit = 1, Fields = PostFields.Id });

            Assert.That(postResponse.Posts.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetPosts_ReturnsLimitedFields_WhenFieldsSpecified()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var post = auth.GetPosts(new PostQueryParams { Limit = 1, Fields = PostFields.Id }).Posts[0];

            Assert.That(post.Id, Is.Not.Null);

            Assert.That(post.Authors, Is.Null);
            Assert.That(post.CodeInjectionFoot, Is.Null);
            Assert.That(post.CodeInjectionHead, Is.Null);
            Assert.That(post.CommentId, Is.Null);
            Assert.That(post.CreatedAt, Is.Null);
            Assert.That(post.CustomExcerpt, Is.Null);
            Assert.That(post.CustomTemplate, Is.Null);
            Assert.That(post.Excerpt, Is.Null);
            Assert.That(post.Featured, Is.Null);
            Assert.That(post.FeatureImage, Is.Null);
            Assert.That(post.Html, Is.Null);
            Assert.That(post.MetaDescription, Is.Null);
            Assert.That(post.MetaTitle, Is.Null);
            Assert.That(post.MobileDoc, Is.Null);
            Assert.That(post.OgDescription, Is.Null);
            Assert.That(post.OgImage, Is.Null);
            Assert.That(post.OgTitle, Is.Null);
            Assert.That(post.PlainText, Is.Null);
            Assert.That(post.PrimaryAuthor, Is.Null);
            Assert.That(post.PrimaryTag, Is.Null);
            Assert.That(post.PublishedAt, Is.Null);
            Assert.That(post.Slug, Is.Null);
            Assert.That(post.Tags, Is.Null);
            Assert.That(post.Title, Is.Null);
            Assert.That(post.TwitterDescription, Is.Null);
            Assert.That(post.TwitterImage, Is.Null);
            Assert.That(post.TwitterTitle, Is.Null);
            Assert.That(post.UpdatedAt, Is.Null);
            Assert.That(post.Url, Is.Null);
            Assert.That(post.Uuid, Is.Null);
        }

        [Test]
        public void GetPosts_ReturnsAuthors_WhenIncludingAuthors()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var post = auth.GetPosts(new PostQueryParams { Limit = 1, IncludeAuthors = true }).Posts[0];

            Assert.That(post.Authors, Is.Not.Null);
            Assert.That(post.PrimaryAuthor, Is.Not.Null);

            Assert.That(post.Tags, Is.Null);
            Assert.That(post.PrimaryTag, Is.Null);
        }

        [Test]
        public void GetPosts_ReturnsTags_WhenIncludingTags()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var post = auth.GetPosts(new PostQueryParams { Limit = 1, IncludeTags = true }).Posts[0];

            Assert.That(post.Tags, Is.Not.Null);
            Assert.That(post.PrimaryTag, Is.Not.Null);

            Assert.That(post.Authors, Is.Null);
            Assert.That(post.PrimaryAuthor, Is.Null);
        }

        [Test]
        public void GetPosts_ReturnsAuthorsAndTags_WhenIncludingAuthorsAndTags()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var post = auth.GetPosts(new PostQueryParams { Limit = 1, IncludeTags = true, IncludeAuthors = true }).Posts[0];

            Assert.That(post.Tags, Is.Not.Null);
            Assert.That(post.PrimaryTag, Is.Not.Null);

            Assert.That(post.Authors, Is.Not.Null);
            Assert.That(post.PrimaryAuthor, Is.Not.Null);
        }

        [Test]
        public void GetPosts_ReturnsAllPosts_WhenNoLimitIsTrue()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var postResponse = auth.GetPosts(new PostQueryParams { Limit = 1, NoLimit = true, Fields = PostFields.Id });

            Assert.That(postResponse.Posts.Count, Is.GreaterThanOrEqualTo(MINIMUM_POST_COUNT_THRESHHOLD));
        }

        [Test]
        public void GetPosts_ReturnsExpectedPost_WhenOrderingByField()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var post = auth.GetPosts(new PostQueryParams { Limit = 1, Order = new List<Tuple<PostFields, OrderDirection>> { Tuple.Create(PostFields.CreatedAt, OrderDirection.asc) } }).Posts[0];

            // potentially fragile
            Assert.That(post.Id, Is.EqualTo("63f50da668bb550001e6f12a"));
        }

        [Test]
        public void GetPosts_ReturnsExpectedPosts_WhenApplyingFilter()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var postResponse = auth.GetPosts(new PostQueryParams { Filter = $"slug:[{ValidPost1Slug}]" });
            Assert.That(postResponse.Posts.Count, Is.EqualTo(1));

            var post = postResponse.Posts[0];

            Assert.That(post.Id, Is.EqualTo(ValidPost1Id));
            Assert.That(post.Slug, Is.EqualTo(ValidPost1Slug));
            Assert.That(post.Title, Is.EqualTo(ValidPost1Title));
            Assert.That(post.Url, Is.EqualTo(ValidPost1Url));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetPosts_ThrowsException_WhenKeyIsInvalid(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            var ex = Assert.Throws<GhostApiException>(() => auth.GetPosts());
            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Unknown Content API Key"));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetPosts_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            Assert.That(auth.GetPosts(), Is.Null);
            Assert.That(auth.LastException, Is.Not.Null);
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetPostById_ThrowsGhostSharpException_WhenIdIsInvalid(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.Throws<GhostApiException>(() => auth.GetPostById(InvalidPostId));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read post."));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetPostById_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            Assert.That(auth.GetPostById(InvalidPostId), Is.Null);
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetPostBySlug_ThrowsGhostSharpException_WhenSlugIsInvalid(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.Throws<GhostApiException>(() => auth.GetPostBySlug(InvalidPostSlug));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read post."));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetPostBySlug_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            Assert.That(auth.GetPostBySlug(InvalidPostSlug), Is.Null);
        }
    }
}
