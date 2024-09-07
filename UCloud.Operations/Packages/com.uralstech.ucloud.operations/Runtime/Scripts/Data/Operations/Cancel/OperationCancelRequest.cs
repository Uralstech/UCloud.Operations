﻿namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// Starts asynchronous cancellation on a long-running operation. The server makes a best effort to cancel the operation, but success is not guaranteed.
    /// </summary>
    /// <remarks>
    /// Clients can use <see cref="OperationGetRequest"/> or other methods to check whether the cancellation succeeded or whether the operation completed despite cancellation.<br/>
    /// On successful cancellation, the operation is not deleted; instead, it becomes an operation with an <see cref="Generic.Operation{TMetadata, TResponse}.Error"/> value with<br/>
    /// a google.rpc.Status.code of 1, corresponding to Code.CANCELLED.
    /// </remarks>
    public class OperationCancelRequest : IOperationsPostRequest
    {
        /// <summary>
        /// The resource name of the operation to cancel.
        /// </summary>
        public string OperationName;

        /// <inheritdoc/>
        public string BaseServiceUri { get; set; } = "https://servicemanagement.googleapis.com/v1";

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            return $"{BaseServiceUri}/{OperationName}:cancel";
        }

        /// <summary>
        /// Creates a new <see cref="OperationCancelRequest"/>.
        /// </summary>
        /// <param name="operationName">The resource name of the operation to cancel.</param>
        public OperationCancelRequest(string operationName)
        {
            OperationName = operationName;
        }
    }
}
