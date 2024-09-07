namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// Requests metadata for an operation. Return type is <see cref="OperationsListResponse"/> or <see cref="Generic.OperationsListResponse{TOperation}"/>.
    /// </summary>
    public class OperationsListRequest : IOperationsGetRequest
    {
        /// <summary>
        /// The conditions for filtering the operations to list.
        /// </summary>
        public OperationFilterConditions Filters;

        /// <summary>
        /// The maximum number of <see cref="Operation"/>s to return (per page).
        /// </summary>
        /// <remarks>
        /// This method returns at most 100 operations per page.
        /// </remarks>
        public int MaxResponseOperations = 50;

        /// <summary>
        /// A page token from a previous <see cref="OperationsListRequest"/> call.
        /// </summary>
        public string PageToken = string.Empty;

        /// <inheritdoc/>
        public string BaseServiceUri { get; set; } = "https://servicemanagement.googleapis.com/v1";

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            return string.IsNullOrEmpty(PageToken)
                ? $"{BaseServiceUri}/operations?filter={Filters}&pageSize={MaxResponseOperations}"
                : $"{BaseServiceUri}/operations?filter={Filters}&pageSize={MaxResponseOperations}&pageToken={PageToken}";
        }

        /// <summary>
        /// Creates a new <see cref="OperationsListRequest"/>.
        /// </summary>
        /// <param name="filters">The conditions for filtering the operations to list.</param>
        public OperationsListRequest(OperationFilterConditions filters)
        {
            Filters = filters;
        }
    }
}
