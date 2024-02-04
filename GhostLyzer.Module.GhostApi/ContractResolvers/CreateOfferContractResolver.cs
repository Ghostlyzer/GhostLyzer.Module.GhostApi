using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace GhostLyzer.Module.GhostApi.ContractResolvers
{
    public class CreateOfferContractResolver : DefaultContractResolver
    {
        // Making it thread-safe by using Lazy<T>
        private static readonly Lazy<CreateOfferContractResolver> lazy = new Lazy<CreateOfferContractResolver>(() => new CreateOfferContractResolver());

        public static CreateOfferContractResolver Instance { get { return lazy.Value; } }

        private CreateOfferContractResolver() { }

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
