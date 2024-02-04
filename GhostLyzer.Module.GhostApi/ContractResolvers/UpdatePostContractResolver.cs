using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;
using GhostLyzer.Module.GhostApi.Attributes;

namespace GhostLyzer.Module.GhostApi.ContractResolvers
{
    public class UpdatePostContractResolver : DefaultContractResolver
    {
        // Singleton instance of the contract resolver, made thread-safe using Lazy<T>
        private static readonly Lazy<UpdatePostContractResolver> lazy = new Lazy<UpdatePostContractResolver>(() => new UpdatePostContractResolver());

        // Public accessor for the singleton instance
        public static UpdatePostContractResolver Instance { get { return lazy.Value; } }

        // Private constructor to prevent direct instantiation
        private UpdatePostContractResolver() { }

        // Override the CreateProperty method of the base class
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            // Create the JSON property using the base class method
            JsonProperty jsonProp = base.CreateProperty(member, memberSerialization);

            // Get the property from the declaring type using reflection
            var property = jsonProp.DeclaringType.GetProperty(nameof(jsonProp.UnderlyingName));

            // Set the ShouldSerialize function, which determines whether the property should be serialized
            jsonProp.ShouldSerialize =
                instance =>
                {
                    // The property should be serialized if it has a public setter
                    // or if it has a RequiredForUpdateAttribute
                    return (property.GetSetMethod()?.IsPublic == true)
                        || property.GetCustomAttribute<RequiredForUpdateAttribute>() is not null;
                };

            // Return the JSON property
            return jsonProp;
        }
    }
}
