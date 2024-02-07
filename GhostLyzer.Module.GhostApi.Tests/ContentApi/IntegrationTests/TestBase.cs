namespace GhostLyzer.Module.GhostApi.Tests.ContentApi.IntegrationTests
{
    public class TestBase
    {
        protected static string Host = "https://blog.christian-schou.dk";
        protected static string SiteTitle = "Tech with Christian";

        protected static string ValidContentApiKey = Environment.GetEnvironmentVariable("CONTENT_API_KEY");

        protected static string ValidPost1Id = "6542b5030a48f800019bb7ae";
        protected static string ValidPost1Slug = "what-are-git-hooks";
        protected static string ValidPost1Title = "What are Git Hooks?";
        protected static string ValidPost1Url = "https://blog.christian-schou.dk/what-are-git-hooks/";
        protected static string ValidPost1Author = "1";
        protected static string ValidPost1PrimaryTag = "5e90d3e71318020e539719f1";
        protected static string ValidPost1CodeInjectionHeader = "<!-- sample code injection header -->";
        protected static string ValidPost1CodeInjectionFooter = "<!-- sample code injection footer -->";

        protected static string ValidPage1Id = "63f50da668bb550001e6f177";
        protected static string ValidPage1Slug = "welcome-free";
        protected static string ValidPage1Url = "https://blog.christian-schou.dk/welcome-free/";
        protected static string ValidPage1Author = "1";

        protected static string ValidAuthor1Id = "1";
        protected static string ValidAuthor1Slug = "christian";
        protected static string ValidAuthor1Name = "Christian Schou";
        protected static string ValidAuthor1Url = "https://blog.christian-schou.dk/author/christian/";

        protected static string ValidAuthor2Id = "2";
        protected static string ValidAuthor2Slug = "nicoline";
        protected static string ValidAuthor2Name = "Nicoline";
        protected static string ValidAuthor2Url = "https://blog.christian-schou.dk/author/nicoline/";

        protected static string ValidAuthorWithNoPublishedPostsSlug = "nicoline";

        protected static string ValidTag1Id = "5e90d3e71318020e53971b03";
        protected static string ValidTag1Slug = "net";
        protected static string ValidTag1Name = ".NET";
        protected static string ValidTag1Description = ".NET (pronounced as \"dot net\"; previously named .NET Core) is a free and open-source, managed computer software framework for Windows, Linux, and macOS operating systems. It is a cross-platform successor to .NET Framework. The project is primarily developed by Microsoft employees by way of the .NET Foundation, and released under the MIT License. - Source: Wikipedia.";
        protected static string ValidTag1FeatureImage = "https://blog.christian-schou.dk/content/images/2023/04/dotnet-twc-hero-bg.webp";
        protected static string ValidTag1Visibility = "public";
        protected static string ValidTag1MetaTitle = "Learn .NET programming with Christian Schou - TWC Blog";
        protected static string ValidTag1MetaDescription = "Learn to utilize the .NET framework to create powerful web applications with C# and .NET. Start from scratch and become a hero with TWC.";
        protected static int ValidTag1PostCount = 52;
        protected static string ValidTag1Url = "https://blog.christian-schou.dk/tag/net/";

        protected static string ValidTag2Id = "5e90d3e71318020e53971b04";
        protected static string ValidTag2Slug = "csharp";
        protected static string ValidTag2Name = "C#";
        protected static string ValidTag2Description = "C# (pronounced \"See Sharp\") is a modern, object-oriented, and type-safe programming language. C# enables developers to build many types of secure and robust applications that run in .NET. C# has its roots in the C family of languages and will be immediately familiar to C, C++, Java, and JavaScript programmers. - Source Microsoft Docs.";

        protected static string ValidTagWithNoPublishedPostsSlug = "learn-csharp";

        protected static string InvalidApiKey = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
        protected static string InvalidPostId = "aaaaaaaaaaaaaaaaaaaaaaaa";
        protected static string InvalidPostSlug = "invalid-slug-value";
        protected static string InvalidPageId = "aaaaaaaaaaaaaaaaaaaaaaaa";
        protected static string InvalidPageSlug = "invalid-slug-value";
        protected static string InvalidAuthorId = "aaaaaaaaaaaaaaaaaaaaaaaa";
        protected static string InvalidAuthorSlug = "invalid-slug-value";
        protected static string InvalidTagId = "aaaaaaaaaaaaaaaaaaaaaaaa";
        protected static string InvalidTagSlug = "invalid-slug-value";

        private readonly List<string> testValues = new List<string> { ValidContentApiKey, ValidPost1Id, ValidPost1Slug,
                                                                      ValidAuthor1Id, ValidAuthor1Slug, ValidTag1Id, ValidTag1Slug};

        protected TestBase()
        {
            if (testValues.Any(string.IsNullOrWhiteSpace))
                throw new ApplicationException("Fill in test values in TestBase before running tests.");
        }
    }
}
