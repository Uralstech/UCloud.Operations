using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Uralstech.UCloud.Operations.Generic
{
    /// <summary>
    /// The generic response for an <see cref="OperationsListRequest"/> call.
    /// </summary>
    /// <typeparam name="TMetadata">The type of the operation's metadata.</typeparam>
    /// <typeparam name="TResponse">The type of the operation's response.</typeparam>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class OperationsListResponse<TMetadata, TResponse>
    {
        /// <summary>
        /// A list of operations that matches the specified filter in the request.
        /// </summary>
        public Operation<TMetadata, TResponse>[] Operations;

        /// <summary>
        /// A token that can be sent as a <see cref="OperationsListRequest.PageToken"/> into a subsequent <see cref="OperationsListRequest"/> call.
        /// </summary>
        public string NextPageToken;
    }
}
