// Copyright 2024 URAV ADVANCED LEARNING SYSTEMS PRIVATE LIMITED
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
                  $"Request Endpoint: {webRequest.uri.AbsoluteUri} | " +
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
