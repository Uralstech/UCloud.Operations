namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// All google.longrunning API requests must inherit from this interface.
    /// </summary>
    public interface IOperationsRequest
    {
        /// <summary>
        /// Gets the URI to the API endpoint.
        /// </summary>
        /// <returns>The URI.</returns>
        public string GetEndpointUri();
    }
}
