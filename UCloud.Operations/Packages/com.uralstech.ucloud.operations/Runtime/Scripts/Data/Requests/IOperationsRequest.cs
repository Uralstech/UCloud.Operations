namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// All google.longrunning API requests must inherit from this interface.
    /// </summary>
    public interface IOperationsRequest
    {
        /// <summary>
        /// The base endpoint URI for the request.
        /// </summary>
        /// <remarks>
        /// This may be a specific service endpoint which contains the operations.
        /// </remarks>
        public string BaseServiceUri { get; set; }

        /// <summary>
        /// Gets the URI to the API endpoint.
        /// </summary>
        /// <returns>The URI.</returns>
        public string GetEndpointUri();
    }
}
