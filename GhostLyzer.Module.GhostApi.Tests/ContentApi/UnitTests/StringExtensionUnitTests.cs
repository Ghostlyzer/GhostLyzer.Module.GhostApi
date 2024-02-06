using GhostLyzer.Module.GhostApi.Enums;
using GhostLyzer.Module.GhostApi.Extensions;

namespace GhostLyzer.Module.GhostApi.Tests.ContentApi.UnitTests
{
    [TestFixture]
    public class StringExtensionUnitTests
    {
        [TestCase(PostFields.Page | PostFields.Slug | PostFields.CommentId, "page,slug,comment_id")]
        [TestCase(PostFields.Uuid | PostFields.Excerpt | PostFields.TwitterImage, "uuid,twitter_image,excerpt")]
        [TestCase(PostFields.PublishedAt, "published_at")]
        [TestCase(0, "")]
        [TestCase(null, "")]
        public void GetQueryStringFromFlagsEnum_ReturnsCommaSeparatedListOfValues(PostFields input, string expectedResult)
        {
            var actualResult = StringExtensions.GetQueryStringFromFlagsEnum<PostFields>(input);

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void GetOrderQueryString_ReturnsCommaSeparatedListOfOrdering_WhenGivenMultipleFields()
        {
            var input = new[]
            {
                Tuple.Create(PostFields.CommentId, OrderDirection.desc),
                Tuple.Create(PostFields.Excerpt, OrderDirection.asc),
                Tuple.Create(PostFields.Id, OrderDirection.desc)
            }.ToList();

            var result = StringExtensions.GetOrderQueryString(input);

            Assert.That("comment_id desc,excerpt asc,id desc", Is.EqualTo(result));
        }

        [Test]
        public void GetOrderQueryString_ReturnsValue_WhenGivenSingleField()
        {
            var input = new[]
            {
                Tuple.Create(PostFields.Slug, OrderDirection.desc)
            }.ToList();

            var result = StringExtensions.GetOrderQueryString(input);

            Assert.That("slug desc", Is.EqualTo(result));
        }

        [Test]
        public void GetOrderQueryString_OmitsInvalidField()
        {
            var input = new[]
            {
                Tuple.Create(PostFields.CommentId, OrderDirection.desc),
                Tuple.Create((PostFields)0, OrderDirection.asc),
                Tuple.Create(PostFields.Id, OrderDirection.desc),
                Tuple.Create((PostFields)333, OrderDirection.desc),
            }.ToList();

            var result = StringExtensions.GetOrderQueryString(input);

            Assert.That("comment_id desc,id desc", Is.EqualTo(result));
        }

        [TestCase(0, 0)]
        [TestCase(99999, 0)]
        [TestCase(null, 0)]
        public void GetOrderQueryString_ReturnsEmptyString_WhenInvalidField(PostFields postFields, OrderDirection orderDirection)
        {
            var input = new[]
            {
                Tuple.Create(postFields, orderDirection)
            }.ToList();

            var result = StringExtensions.GetOrderQueryString(input);

            Assert.That("", Is.EqualTo(result));
        }

        [TestCase(PostFields.Excerpt, "excerpt")]
        [TestCase(PostFields.CreatedAt, "created_at")]
        [TestCase(0, null)]
        [TestCase(333, null)]
        public void GetFieldName_ReturnsCorrectFieldName(PostFields input, string expectedResult)
        {
            Assert.That(expectedResult, Is.EqualTo(StringExtensions.GetFieldName(input)));
        }
    }
}
