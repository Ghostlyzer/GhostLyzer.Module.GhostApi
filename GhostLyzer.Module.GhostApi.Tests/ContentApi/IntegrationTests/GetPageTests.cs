using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Exceptions;
using GhostLyzer.Module.GhostApi.QueryParams;
using GhostLyzer.Module.GhostApi.Services;

namespace GhostLyzer.Module.GhostApi.Tests.ContentApi.IntegrationTests
{
    [TestFixture]
    public class GetPageIntegrationTests : TestBase
    {
        private const int MINIMUM_PAGE_COUNT_THRESHHOLD = 4;

        private GhostAPI auth;

        [SetUp]
        public void SetUp()
        {
            auth = new GhostContentAPI(Host, ValidContentApiKey);
        }

        [Test]
        public void GetPageById_ReturnsMatchingPage()
        {
            var page = auth.GetPageById(ValidPage1Id);

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Uuid, Is.Not.Null);
            Assert.That(page.Html, Is.Not.Null);
            Assert.That(page.CommentId, Is.Not.Null);
            Assert.That(page.CreatedAt, Is.Not.Null);
            Assert.That(page.UpdatedAt, Is.Not.Null);
            Assert.That(page.PublishedAt, Is.Not.Null);
            Assert.That(page.Url, Is.Not.Null);
            Assert.That(page.Excerpt, Is.Not.Null);

            Assert.That(page.MetaTitle, Is.Null);
            Assert.That(page.CodeInjectionHead, Is.Null);
            Assert.That(page.CodeInjectionFoot, Is.Null);
            Assert.That(page.OgImage, Is.Null);
            Assert.That(page.OgTitle, Is.Null);
            Assert.That(page.TwitterImage, Is.Null);
            Assert.That(page.TwitterTitle, Is.Null);
            Assert.That(page.CustomTemplate, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
            Assert.That(page.Authors, Is.Null);
            Assert.That(page.Tags, Is.Null);
        }

        [Test]
        public async Task GetPageById_ReturnsMatchingPage_Async()
        {
            var page = await auth.GetPageByIdAsync(ValidPage1Id);

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Uuid, Is.Not.Null);
            Assert.That(page.Html, Is.Not.Null);
            Assert.That(page.CommentId, Is.Not.Null);
            Assert.That(page.CreatedAt, Is.Not.Null);
            Assert.That(page.UpdatedAt, Is.Not.Null);
            Assert.That(page.PublishedAt, Is.Not.Null);
            Assert.That(page.Url, Is.Not.Null);
            Assert.That(page.Excerpt, Is.Not.Null);

            Assert.That(page.MetaTitle, Is.Null);
            Assert.That(page.CodeInjectionHead, Is.Null);
            Assert.That(page.CodeInjectionFoot, Is.Null);
            Assert.That(page.OgImage, Is.Null);
            Assert.That(page.OgTitle, Is.Null);
            Assert.That(page.TwitterImage, Is.Null);
            Assert.That(page.TwitterTitle, Is.Null);
            Assert.That(page.CustomTemplate, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
            Assert.That(page.Authors, Is.Null);
            Assert.That(page.Tags, Is.Null);
        }

        [Test]
        public void GetPageById_ReturnsAuthors_WhenIncludingAuthors()
        {
            var page = auth.GetPageById(ValidPage1Id, new PostQueryParams { IncludeAuthors = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
            Assert.That(page.Authors[0].Id, Is.EqualTo(ValidPage1Author));
            Assert.That(page.PrimaryAuthor.Id, Is.EqualTo(ValidPage1Author));

            Assert.That(page.Tags, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
        }

        [Test]
        public async Task GetPageById_ReturnsAuthors_WhenIncludingAuthors_Async()
        {
            var page = await auth.GetPageByIdAsync(ValidPage1Id, new PostQueryParams { IncludeAuthors = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
            Assert.That(page.Authors[0].Id, Is.EqualTo(ValidPage1Author));
            Assert.That(page.PrimaryAuthor.Id, Is.EqualTo(ValidPage1Author));

            Assert.That(page.Tags, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
        }

        [Test]
        public void GetPageById_ReturnsTags_WhenIncludingTags()
        {
            var page = auth.GetPageById(ValidPage1Id, new PostQueryParams { IncludeTags = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Tags, Is.Not.Null);
        }

        [Test]
        public async Task GetPageById_ReturnsTags_WhenIncludingTags_Async()
        {
            var page = await auth.GetPageByIdAsync(ValidPage1Id, new PostQueryParams { IncludeTags = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Tags, Is.Not.Null);
        }

        [Test]
        public void GetPageById_ReturnsAuthorsAndTags_WhenIncludingAuthorsAndTags()
        {
            var page = auth.GetPageById(ValidPage1Id, new PostQueryParams { IncludeAuthors = true, IncludeTags = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
            Assert.That(page.Authors[0].Id, Is.EqualTo(ValidPage1Author));
            Assert.That(page.PrimaryAuthor.Id, Is.EqualTo(ValidPage1Author));
        }

        [Test]
        public async Task GetPageById_ReturnsAuthorsAndTags_WhenIncludingAuthorsAndTags_Async()
        {
            var page = await auth.GetPageByIdAsync(ValidPage1Id, new PostQueryParams { IncludeAuthors = true, IncludeTags = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
            Assert.That(page.Authors[0].Id, Is.EqualTo(ValidPage1Author));
            Assert.That(page.PrimaryAuthor.Id, Is.EqualTo(ValidPage1Author));
        }

        [Test]
        public void GetPageById_ReturnsLimitedFields_WhenFieldsSpecified()
        {
            var page = auth.GetPageById(ValidPage1Id, new PostQueryParams { Fields = PostFields.Id | PostFields.Slug });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Title, Is.Null);
            Assert.That(page.Url, Is.Null);
        }

        [Test]
        public async Task GetPageById_ReturnsLimitedFields_WhenFieldsSpecified_Async()
        {
            var page = await auth.GetPageByIdAsync(ValidPage1Id, new PostQueryParams { Fields = PostFields.Id | PostFields.Slug });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Title, Is.Null);
            Assert.That(page.Url, Is.Null);
        }

        [Test]
        public void GetPageBySlug_ReturnsMatchingPage()
        {
            var page = auth.GetPageBySlug(ValidPage1Slug);

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Uuid, Is.Not.Null);
            Assert.That(page.Html, Is.Not.Null);
            Assert.That(page.CommentId, Is.Not.Null);
            Assert.That(page.CreatedAt, Is.Not.Null);
            Assert.That(page.UpdatedAt, Is.Not.Null);
            Assert.That(page.PublishedAt, Is.Not.Null);
            Assert.That(page.Url, Is.Not.Null);
            Assert.That(page.Excerpt, Is.Not.Null);
            Assert.That(page.Title, Is.Not.Null);

            Assert.That(page.MetaTitle, Is.Null);
            Assert.That(page.CodeInjectionHead, Is.Null);
            Assert.That(page.CodeInjectionFoot, Is.Null);
            Assert.That(page.OgImage, Is.Null);
            Assert.That(page.OgTitle, Is.Null);
            Assert.That(page.TwitterImage, Is.Null);
            Assert.That(page.TwitterTitle, Is.Null);
            Assert.That(page.CustomTemplate, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
            Assert.That(page.Authors, Is.Null);
            Assert.That(page.Tags, Is.Null);
        }

        [Test]
        public async Task GetPageBySlug_ReturnsMatchingPage_Async()
        {
            var page = await auth.GetPageBySlugAsync(ValidPage1Slug);

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Uuid, Is.Not.Null);
            Assert.That(page.Html, Is.Not.Null);
            Assert.That(page.CommentId, Is.Not.Null);
            Assert.That(page.CreatedAt, Is.Not.Null);
            Assert.That(page.UpdatedAt, Is.Not.Null);
            Assert.That(page.PublishedAt, Is.Not.Null);
            Assert.That(page.Url, Is.Not.Null);
            Assert.That(page.Excerpt, Is.Not.Null);
            Assert.That(page.Title, Is.Not.Null);

            Assert.That(page.MetaTitle, Is.Null);
            Assert.That(page.CodeInjectionHead, Is.Null);
            Assert.That(page.CodeInjectionFoot, Is.Null);
            Assert.That(page.OgImage, Is.Null);
            Assert.That(page.OgTitle, Is.Null);
            Assert.That(page.TwitterImage, Is.Null);
            Assert.That(page.TwitterTitle, Is.Null);
            Assert.That(page.CustomTemplate, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
            Assert.That(page.Authors, Is.Null);
            Assert.That(page.Tags, Is.Null);
        }

        [Test]
        public void GetPageBySlug_ReturnsAuthors_WhenIncludingAuthors()
        {
            var page = auth.GetPageBySlug(ValidPage1Slug, new PostQueryParams { IncludeAuthors = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
            Assert.That(page.Authors[0].Id, Is.EqualTo(ValidPage1Author));
            Assert.That(page.PrimaryAuthor.Id, Is.EqualTo(ValidPage1Author));

            Assert.That(page.Tags, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
        }

        [Test]
        public async Task GetPageBySlug_ReturnsAuthors_WhenIncludingAuthors_Async()
        {
            var page = await auth.GetPageBySlugAsync(ValidPage1Slug, new PostQueryParams { IncludeAuthors = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
            Assert.That(page.Authors[0].Id, Is.EqualTo(ValidPage1Author));
            Assert.That(page.PrimaryAuthor.Id, Is.EqualTo(ValidPage1Author));

            Assert.That(page.Tags, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
        }

        [Test]
        public void GetPageBySlug_ReturnsTags_WhenIncludingTags()
        {
            var page = auth.GetPageBySlug(ValidPage1Slug, new PostQueryParams { IncludeTags = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
        }

        [Test]
        public async Task GetPageBySlug_ReturnsTags_WhenIncludingTags_Async()
        {
            var page = await auth.GetPageBySlugAsync(ValidPage1Slug, new PostQueryParams { IncludeTags = true });
            
            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
        }

        [Test]
        public void GetPageBySlug_ReturnsAuthorsAndTags_WhenIncludingAuthorsAndTags()
        {
            var page = auth.GetPageBySlug(ValidPage1Slug, new PostQueryParams { IncludeAuthors = true, IncludeTags = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
            Assert.That(page.Authors[0].Id, Is.EqualTo(ValidPage1Author));
            Assert.That(page.PrimaryAuthor.Id, Is.EqualTo(ValidPage1Author));
        }

        [Test]
        public async Task GetPageBySlug_ReturnsAuthorsAndTags_WhenIncludingAuthorsAndTags_Async()
        {
            var page = await auth.GetPageBySlugAsync(ValidPage1Slug, new PostQueryParams { IncludeAuthors = true, IncludeTags = true });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
            Assert.That(page.Authors[0].Id, Is.EqualTo(ValidPage1Author));
            Assert.That(page.PrimaryAuthor.Id, Is.EqualTo(ValidPage1Author));
        }

        [Test]
        public void GetPageBySlug_ReturnsLimitedFields_WhenFieldsSpecified()
        {
            var page = auth.GetPageBySlug(ValidPage1Slug, new PostQueryParams { Fields = PostFields.Id | PostFields.Slug });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Title, Is.Null);
            Assert.That(page.Url, Is.Null);
        }

        [Test]
        public async Task GetPageBySlug_ReturnsLimitedFields_WhenFieldsSpecified_Async()
        {
            var page = await auth.GetPageBySlugAsync(ValidPage1Slug, new PostQueryParams { Fields = PostFields.Id | PostFields.Slug });

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Title, Is.Null);
            Assert.That(page.Url, Is.Null);
        }

        [Test]
        public void GetPages_ReturnsLimitedPages_WhenLimitSpecified()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = auth.GetPages(new PostQueryParams { Limit = 1, Fields = PostFields.Id });

            Assert.That(pageResponse.Pages.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetPages_ReturnsLimitedPages_WhenLimitSpecified_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = await auth.GetPagesAsync(new PostQueryParams { Limit = 1, Fields = PostFields.Id });

            Assert.That(pageResponse.Pages.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetPages_ReturnsLimitedFields_WhenFieldsSpecified()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var page = auth.GetPages(new PostQueryParams { Limit = 1, Fields = PostFields.Id }).Pages[0];

            Assert.That(page.Id, Is.Not.Null);

            Assert.That(page.Authors, Is.Null);
            Assert.That(page.CodeInjectionFoot, Is.Null);
            Assert.That(page.CodeInjectionHead, Is.Null);
            Assert.That(page.CommentId, Is.Null);
            Assert.That(page.CreatedAt, Is.Null);
            Assert.That(page.CustomExcerpt, Is.Null);
            Assert.That(page.CustomTemplate, Is.Null);
            Assert.That(page.Excerpt, Is.Null);
            Assert.That(page.Featured, Is.Null);
            Assert.That(page.FeatureImage, Is.Null);
            Assert.That(page.Html, Is.Null);
            Assert.That(page.MetaDescription, Is.Null);
            Assert.That(page.MetaTitle, Is.Null);
            Assert.That(page.MobileDoc, Is.Null);
            Assert.That(page.OgDescription, Is.Null);
            Assert.That(page.OgImage, Is.Null);
            Assert.That(page.OgTitle, Is.Null);
            Assert.That(page.PlainText, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
            Assert.That(page.PublishedAt, Is.Null);
            Assert.That(page.Slug, Is.Null);
            Assert.That(page.Tags, Is.Null);
            Assert.That(page.Title, Is.Null);
            Assert.That(page.TwitterDescription, Is.Null);
            Assert.That(page.TwitterImage, Is.Null);
            Assert.That(page.TwitterTitle, Is.Null);
            Assert.That(page.UpdatedAt, Is.Null);
            Assert.That(page.Url, Is.Null);
            Assert.That(page.Uuid, Is.Null);
        }

        [Test]
        public async Task GetPages_ReturnsLimitedFields_WhenFieldsSpecified_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = await auth.GetPagesAsync(new PostQueryParams { Limit = 1, Fields = PostFields.Id });
            var page = pageResponse.Pages[0];

            Assert.That(page.Id, Is.Not.Null);

            Assert.That(page.Authors, Is.Null);
            Assert.That(page.CodeInjectionFoot, Is.Null);
            Assert.That(page.CodeInjectionHead, Is.Null);
            Assert.That(page.CommentId, Is.Null);
            Assert.That(page.CreatedAt, Is.Null);
            Assert.That(page.CustomExcerpt, Is.Null);
            Assert.That(page.CustomTemplate, Is.Null);
            Assert.That(page.Excerpt, Is.Null);
            Assert.That(page.Featured, Is.Null);
            Assert.That(page.FeatureImage, Is.Null);
            Assert.That(page.Html, Is.Null);
            Assert.That(page.MetaDescription, Is.Null);
            Assert.That(page.MetaTitle, Is.Null);
            Assert.That(page.MobileDoc, Is.Null);
            Assert.That(page.OgDescription, Is.Null);
            Assert.That(page.OgImage, Is.Null);
            Assert.That(page.OgTitle, Is.Null);
            Assert.That(page.PlainText, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
            Assert.That(page.PublishedAt, Is.Null);
            Assert.That(page.Slug, Is.Null);
            Assert.That(page.Tags, Is.Null);
            Assert.That(page.Title, Is.Null);
            Assert.That(page.TwitterDescription, Is.Null);
            Assert.That(page.TwitterImage, Is.Null);
            Assert.That(page.TwitterTitle, Is.Null);
            Assert.That(page.UpdatedAt, Is.Null);
            Assert.That(page.Url, Is.Null);
            Assert.That(page.Uuid, Is.Null);
        }

        [Test]
        public void GetPages_ReturnsAuthors_WhenIncludingAuthors()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var page = auth.GetPages(new PostQueryParams { Limit = 1, IncludeAuthors = true }).Pages[0];

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);

            Assert.That(page.Tags, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
        }

        [Test]
        public async Task GetPages_ReturnsAuthors_WhenIncludingAuthors_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = await auth.GetPagesAsync(new PostQueryParams { Limit = 1, IncludeAuthors = true });
            var page = pageResponse.Pages[0];

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);

            Assert.That(page.Tags, Is.Null);
            Assert.That(page.PrimaryTag, Is.Null);
        }

        [Test]
        public void GetPages_ReturnsTags_WhenIncludingTags()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var page = auth.GetPages(new PostQueryParams { Limit = 1, IncludeTags = true }).Pages[0];

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
        }

        [Test]
        public async Task GetPages_ReturnsTags_WhenIncludingTags_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = await auth.GetPagesAsync(new PostQueryParams { Limit = 1, IncludeTags = true });
            var page = pageResponse.Pages[0];

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Null);
            Assert.That(page.PrimaryAuthor, Is.Null);
        }

        [Test]
        public void GetPages_ReturnsAuthorsAndTags_WhenIncludingAuthorsAndTags()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var page = auth.GetPages(new PostQueryParams { Limit = 1, IncludeTags = true, IncludeAuthors = true }).Pages[0];

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
        }

        [Test]
        public async Task GetPages_ReturnsAuthorsAndTags_WhenIncludingAuthorsAndTags_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = await auth.GetPagesAsync(new PostQueryParams { Limit = 1, IncludeTags = true, IncludeAuthors = true });
            var page = pageResponse.Pages[0];

            Assert.That(page.Tags, Is.Not.Null);

            Assert.That(page.Authors, Is.Not.Null);
            Assert.That(page.PrimaryAuthor, Is.Not.Null);
        }

        [Test]
        public void GetPages_ReturnsAllPages_WhenNoLimitIsTrue()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = auth.GetPages(new PostQueryParams { Limit = 1, NoLimit = true, Fields = PostFields.Id });

            Assert.That(pageResponse.Pages.Count, Is.GreaterThanOrEqualTo(MINIMUM_PAGE_COUNT_THRESHHOLD));
        }

        [Test]
        public async Task GetPages_ReturnsAllPages_WhenNoLimitIsTrue_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = await auth.GetPagesAsync(new PostQueryParams { Limit = 1, NoLimit = true, Fields = PostFields.Id });

            Assert.That(pageResponse.Pages.Count, Is.GreaterThanOrEqualTo(MINIMUM_PAGE_COUNT_THRESHHOLD));
        }

        [Test]
        public void GetPages_ReturnsExpectedPage_WhenOrderingByField()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var page = auth.GetPages(new PostQueryParams { Limit = 1, Order = new List<Tuple<PostFields, OrderDirection>> { Tuple.Create(PostFields.CreatedAt, OrderDirection.asc) } }).Pages[0];

            // potentially fragile
            Assert.That(page.Id, Is.EqualTo("63f50da668bb550001e6f129"));
        }

        [Test]
        public async Task GetPages_ReturnsExpectedPage_WhenOrderingByField_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = await auth.GetPagesAsync(new PostQueryParams { Limit = 1, Order = new List<Tuple<PostFields, OrderDirection>> { Tuple.Create(PostFields.CreatedAt, OrderDirection.asc) } });
            var page = pageResponse.Pages[0];

            // potentially fragile
            Assert.That(page.Id, Is.EqualTo("63f50da668bb550001e6f129"));
        }

        [Test]
        public void GetPages_ReturnsExpectedPage_WhenGettingSecondPage()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var page = auth.GetPages(new PostQueryParams { Page = 2, Limit = 2, Order = new List<Tuple<PostFields, OrderDirection>> { Tuple.Create(PostFields.CreatedAt, OrderDirection.asc) }, Fields = PostFields.Id }).Pages[0];

            // potentially fragile
            Assert.That(page.Id, Is.EqualTo("63f50da668bb550001e6f177"));
        }

        [Test]
        public async Task GetPages_ReturnsExpectedPage_WhenGettingSecondPage_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = await auth.GetPagesAsync(new PostQueryParams { Page = 2, Limit = 2, Order = new List<Tuple<PostFields, OrderDirection>> { Tuple.Create(PostFields.CreatedAt, OrderDirection.asc) }, Fields = PostFields.Id });
            var page = pageResponse.Pages[0];

            // potentially fragile
            Assert.That(page.Id, Is.EqualTo("63f50da668bb550001e6f177"));
        }

        [Test]
        public void GetPages_ReturnsExpectedPages_WhenApplyingFilter()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = auth.GetPages(new PostQueryParams { Filter = $"slug:[{ValidPage1Slug}]" });
            Assert.That(pageResponse.Pages.Count, Is.EqualTo(1));

            var page = pageResponse.Pages[0];

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));
        }

        [Test]
        public async Task GetPages_ReturnsExpectedPages_WhenApplyingFilter_Async()
        {
            var auth = new GhostContentAPI(Host, ValidContentApiKey);

            var pageResponse = await auth.GetPagesAsync(new PostQueryParams { Filter = $"slug:[{ValidPage1Slug}]" });
            Assert.That(pageResponse.Pages.Count, Is.EqualTo(1));

            var page = pageResponse.Pages[0];

            Assert.That(page.Id, Is.EqualTo(ValidPage1Id));
            Assert.That(page.Slug, Is.EqualTo(ValidPage1Slug));
            Assert.That(page.Url, Is.EqualTo(ValidPage1Url));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetPages_ThrowsException_WhenKeyIsInvalid(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            var ex = Assert.Throws<GhostApiException>(() => auth.GetPages());
            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Unknown Content API Key"));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public async Task GetPages_ThrowsException_WhenKeyIsInvalid_Async(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            var ex = Assert.ThrowsAsync<GhostApiException>(() => auth.GetPagesAsync());
            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Unknown Content API Key"));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetPages_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            Assert.That(auth.GetPages(), Is.Null);
            Assert.That(auth.LastException, Is.Not.Null);
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public async Task GetPages_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed_Async(ExceptionLevel exceptionLevel)
        {
            var auth = new GhostContentAPI(Host, InvalidApiKey) { ExceptionLevel = exceptionLevel };

            Assert.That(await auth.GetPagesAsync(), Is.Null);
            Assert.That(auth.LastException, Is.Not.Null);
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetPageById_ThrowsGhostSharpException_WhenIdIsInvalid(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.Throws<GhostApiException>(() => auth.GetPageById(InvalidPageId));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read page."));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public async Task GetPageById_ThrowsGhostSharpException_WhenIdIsInvalid_Async(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.ThrowsAsync<GhostApiException>(() => auth.GetPageByIdAsync(InvalidPageId));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read page."));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetPageById_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            Assert.That(auth.GetPageById(InvalidPageId), Is.Null);
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public async Task GetPageById_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed_Async(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            Assert.That(await auth.GetPageByIdAsync(InvalidPageId), Is.Null);
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public void GetPageBySlug_ThrowsGhostSharpException_WhenSlugIsInvalid(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.Throws<GhostApiException>(() => auth.GetPageBySlug(InvalidPageSlug));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read page."));
        }

        [TestCase(ExceptionLevel.Ghost)]
        [TestCase(ExceptionLevel.All)]
        public async Task GetPageBySlug_ThrowsGhostSharpException_WhenSlugIsInvalid_Async(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            var ex = Assert.ThrowsAsync<GhostApiException>(() => auth.GetPageBySlugAsync(InvalidPageSlug));

            Assert.That(ex.Errors, Is.Not.Empty);
            Assert.That(ex.Errors[0].Message, Is.EqualTo("Resource not found error, cannot read page."));
        }

        [TestCase(ExceptionLevel.None)]
        [TestCase(ExceptionLevel.NonGhost)]
        public void GetPageBySlug_ReturnsNull_WhenKeyIsInvalid_AndGhostExceptionsSuppressed(ExceptionLevel exceptionLevel)
        {
            auth.ExceptionLevel = exceptionLevel;

            Assert.That(auth.GetPageBySlug(InvalidPageSlug), Is.Null);
        }
    }
}
