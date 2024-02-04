using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace GhostLyzer.Module.GhostApi.ContractResolvers
{
    public class UpdateOfferContractResolver : DefaultContractResolver
    {
        private static readonly Lazy<UpdateOfferContractResolver> lazy = new Lazy<UpdateOfferContractResolver>(() => new UpdateOfferContractResolver());

        public static UpdateOfferContractResolver Instance { get { return lazy.Value; } }

        private UpdateOfferContractResolver() { }

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
