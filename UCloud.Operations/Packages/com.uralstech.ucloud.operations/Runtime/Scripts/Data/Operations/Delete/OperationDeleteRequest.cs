namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// Deletes a long-running operation. This method indicates that the client is no longer interested in the operation result. It does not cancel the operation.
    /// </summary>
    public class OperationDeleteRequest : IOperationsDeleteRequest
    {
        /// <summary>
        /// The resource name of the operation to delete.
        /// </summary>
        public string OperationName;

        /// <inheritdoc/>
        public string BaseServiceUri { get; set; } = "https://servicemanagement.googleapis.com/v1";

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            return $"{BaseServiceUri}/{OperationName}";
        }

        /// <summary>
        /// Creates a new <see cref="OperationDeleteRequest"/>.
        /// </summary>
        /// <param name="operationName">The resource name of the operation to delete.</param>
        public OperationDeleteRequest(string operationName)
        {
            OperationName = operationName;
        }
    }
}
