using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace GhostLyzer.Module.GhostApi.ContractResolvers
{
    public class CreatePageContractResolver : DefaultContractResolver
    {
        // Making it thread-safe by using Lazy<T>
        private static readonly Lazy<CreatePageContractResolver> lazy = new Lazy<CreatePageContractResolver>(() => new CreatePageContractResolver());

        public static CreatePageContractResolver Instance { get { return lazy.Value; } }

        private CreatePageContractResolver() { }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty jsonProp = base.CreateProperty(member, memberSerialization);

            var property = jsonProp.DeclaringType.GetProperty(nameof(jsonProp.UnderlyingName));

            jsonProp.ShouldSerialize =
                instance =>
                {
                    return property.GetSetMethod() is not null;
                };

            return jsonProp;
        }
    }
}
