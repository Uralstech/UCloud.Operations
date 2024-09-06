using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// The response for an <see cref="OperationsListRequest"/> call.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class OperationsListResponse
    {
        /// <summary>
        /// A list of operations that matches the specified filter in the request.
        /// </summary>
        public Operation[] Operations;

        /// <summary>
        /// A token that can be sent as a <see cref="OperationsListRequest.PageToken"/> into a subsequent <see cref="OperationsListRequest"/> call.
        /// </summary>
        public string NextPageToken;
    }
}
