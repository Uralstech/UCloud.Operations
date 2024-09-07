using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// The response for an <see cref="OperationsListRequest"/> call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class OperationsListResponse : Generic.OperationsListResponse<Operation> {}
}
