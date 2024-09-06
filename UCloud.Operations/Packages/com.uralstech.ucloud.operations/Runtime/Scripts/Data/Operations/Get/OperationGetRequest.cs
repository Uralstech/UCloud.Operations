namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// Gets the latest state of a long-running operation. Clients can use this method to poll the operation result at intervals as recommended by the API service.
    /// </summary>
    /// <remarks>
    /// Return type is <see cref="Operation"/> or <see cref="Generic.Operation{TMetadata, TResponse}"/>.
    /// </remarks>
    public class OperationGetRequest : IOperationsGetRequest
    {
        /// <summary>
        /// The resource name of the operation to get.
        /// </summary>
        public string OperationName;

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            return $"https://servicemanagement.googleapis.com/v1/{OperationName}";
        }

        /// <summary>
        /// Creates a new <see cref="OperationGetRequest"/>.
        /// </summary>
        /// <param name="operationName">The resource name of the operation to get.</param>
        public OperationGetRequest(string operationName)
        {
            OperationName = operationName;
        }
    }
}
