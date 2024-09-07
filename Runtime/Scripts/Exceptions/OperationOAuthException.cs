using System;
using UnityEngine.Networking;

namespace Uralstech.UCloud.Operations.Exceptions
{
    /// <summary>
    /// Thrown when an exception related to OAuth authentication is raised.
    /// </summary>
    public class OperationOAuthException : Exception
    {
        /// <summary>
        /// The endpoint of the request.
        /// </summary>
        public Uri RequestEndpoint;

        /// <summary>
        /// The reason for the exception.
        /// </summary>
        public string Reason;

        /// <summary>
        /// Creates a new <see cref="OperationOAuthException"/>.
        /// </summary>
        /// <param name="webRequest">The request that caused the exception.</param>
        internal OperationOAuthException(UnityWebRequest webRequest, string reason)
            : base($"Failed to authenticate google.longrunning API request: " +
                  $"Request Endpoint: {webRequest.uri.AbsoluteUri} | " +
                  $"Reason:\n{reason}")
        {
            RequestEndpoint = webRequest.uri;
            Reason = reason;
        }
    }
}
