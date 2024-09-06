using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Uralstech.UCloud
{
    /// <summary>
    /// An object containing fields of an arbitrary type.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ProtobufObject
    {
        /// <summary>
        /// Contains a URI identifying the type.
        /// </summary>
        [JsonProperty("@type")]
        public string Type;

        /// <summary>
        /// The actual details of the <see cref="ProtobufObject"/> object.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, JToken> Data;
    }
}
