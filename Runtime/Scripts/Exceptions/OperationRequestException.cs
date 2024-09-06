using System;
using UnityEngine.Networking;

namespace Uralstech.UCloud.Operations.Exceptions
{
    /// <summary>
    /// Thrown if a google.longrunning API request fails.
    /// </summary>
    public class OperationRequestException : Exception
    {
        /// <summary>
        /// The endpoint of the failed request.
        /// </summary>
        public Uri RequestEndpoint;

        /// <summary>
        /// The response code returned by the request.
        /// </summary>
        public long RequestErrorCode;

        /// <summary>
        /// The name of the request's error.
        /// </summary>
        public string RequestError;

        /// <summary>
        /// The request's error message.
        /// </summary>
        public string RequestErrorMessage;

        /// <summary>
        /// Creates a new <see cref="OperationRequestException"/>.
        /// </summary>
        /// <param name="webRequest">The request that caused the exception.</param>
        internal OperationRequestException(UnityWebRequest webRequest)
            : base($"Failed google.longrunning API request: " +
                  $"Request Endpoint: {webRequest.uri.AbsolutePath} | " +
                  $"Request Error Code: {webRequest.responseCode} | " +
                  $"Request Error: {webRequest.error} | " +
                  $"Details:\n{webRequest.downloadHandler?.text}")
        {
            RequestEndpoint = webRequest.uri;

            RequestError = webRequest.error;
            RequestErrorCode = webRequest.responseCode;
            RequestErrorMessage = webRequest.downloadHandler?.text;
        }
    }
}
