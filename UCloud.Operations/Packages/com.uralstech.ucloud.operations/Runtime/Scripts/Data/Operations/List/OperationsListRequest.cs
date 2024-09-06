namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// Requests metadata for an operation. Return type is <see cref="OperationsListResponse"/> or <see cref="Generic.OperationsListResponse{TMetadata, TResponse}"/>.
    /// </summary>
    public class OperationsListRequest : IOperationsGetRequest
    {
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
        public string GetEndpointUri()
        {
            return string.IsNullOrEmpty(PageToken)
                ? $"https://servicemanagement.googleapis.com/v1/operations?pageSize={MaxResponseOperations}"
                : $"https://servicemanagement.googleapis.com/v1/operations?pageSize={MaxResponseOperations}&pageToken={PageToken}";
        }
    }
}
