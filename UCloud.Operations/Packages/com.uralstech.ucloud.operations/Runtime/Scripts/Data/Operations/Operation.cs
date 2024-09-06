using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// This resource represents a long-running operation that is the result of a network API call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Operation : Generic.Operation<ProtobufObject, ProtobufObject> { }
}
