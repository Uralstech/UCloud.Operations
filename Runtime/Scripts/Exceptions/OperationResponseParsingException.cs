using System;
using UnityEngine.Networking;

namespace Uralstech.UCloud.Operations.Exceptions
{
    /// <summary>
    /// Thrown if the response of a google.longrunning API request could not be parsed.
    /// </summary>
    public class OperationResponseParsingException : Exception
    {
        /// <summary>
        /// The endpoint of the request.
        /// </summary>
        public Uri RequestEndpoint;

        /// <summary>
        /// The content downloaded from the request.
        /// </summary>
        public string DownloadedText;

        /// <summary>
        /// Creates a new <see cref="OperationResponseParsingException"/>.
        /// </summary>
        /// <param name="webRequest">The request that caused the exception.</param>
        internal OperationResponseParsingException(UnityWebRequest webRequest)
            : base($"Failed to parse google.longrunning API response: " +
                  $"Request Endpoint: {webRequest.uri.AbsolutePath} | " +
                  $"Downloaded Text:\n{webRequest.downloadHandler?.text}")
        {
            RequestEndpoint = webRequest.uri;
            DownloadedText = webRequest.downloadHandler?.text;
        }

        /// <summary>
        /// Creates a new <see cref="OperationResponseParsingException"/>.
        /// </summary>
        /// <param name="webRequest">The request that caused the exception.</param>
        /// <param name="innerException">The inner exception that caused this one.</param>
        internal OperationResponseParsingException(UnityWebRequest webRequest, Exception innerException)
            : base($"Failed to parse google.longrunning API response: " +
                  $"Request Endpoint: {webRequest.uri.AbsoluteUri} | " +
                  $"Downloaded Text:\n{webRequest.downloadHandler?.text}", innerException)
        {
            RequestEndpoint = webRequest.uri;
            DownloadedText = webRequest.downloadHandler?.text;
        }
    }
}
