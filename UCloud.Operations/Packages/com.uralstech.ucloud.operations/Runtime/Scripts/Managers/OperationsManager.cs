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

using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Uralstech.UCloud.Operations.Exceptions;
using Uralstech.Utils.Singleton;

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// The class for accessing the google.longrunning API!
    /// </summary>
    [AddComponentMenu("Uralstech/UCloud/Operations/Operations Manager")]
    public class OperationsManager : Singleton<OperationsManager>
    {
        /// <summary>
        /// An empty JSON object.
        /// </summary>
        private const string EmptyJsonObject = "{}";

        /// <summary>
        /// Computes a GET request on the google.longrunning API.
        /// </summary>
        /// 
        /// <typeparam name="TResponse">
        /// The response type. For example, a request of type <see cref="OperationsListRequest"/> corresponds
        /// to a response type of <see cref="OperationsListResponse"/> or <see cref="Generic.OperationsListResponse{TOperation}"/>.
        /// </typeparam>
        /// 
        /// <param name="accessToken">The OAuth Access Token to use for authentication.</param>
        /// <param name="request">The request object.</param>
        /// <returns>The computed response.</returns>
        /// <exception cref="OperationOAuthException">Thrown if the request could not be authenticated.</exception>
        /// <exception cref="OperationRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="OperationResponseParsingException">Thrown if the response could not be parsed.</exception>
        public async Task<TResponse> Request<TResponse>(string accessToken, IOperationsGetRequest request)
        {
            string requestEndpoint = request.GetEndpointUri();

            using UnityWebRequest webRequest = UnityWebRequest.Get(requestEndpoint);
            await ComputeRequest(accessToken, webRequest);

            return ConfirmResponse<TResponse>(webRequest);
        }

        /// <summary>
        /// Computes a DELETE request on the google.longrunning API.
        /// </summary>
        /// <param name="accessToken">The OAuth Access Token to use for authentication.</param>
        /// <param name="request">The request object.</param>
        /// <exception cref="OperationOAuthException">Thrown if the request could not be authenticated.</exception>
        /// <exception cref="OperationRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="OperationResponseParsingException">Thrown if the response could not be parsed.</exception>
        public async Task Request(string accessToken, IOperationsDeleteRequest request)
        {
            string requestEndpoint = request.GetEndpointUri();

            using UnityWebRequest webRequest = UnityWebRequest.Delete(requestEndpoint);
            await ComputeRequest(accessToken, webRequest);

            ConfirmResponse(webRequest);
        }

        /// <summary>
        /// Computes an empty POST request on the google.longrunning API.
        /// </summary>
        /// <param name="accessToken">The OAuth Access Token to use for authentication.</param>
        /// <param name="request">The request object.</param>
        /// <exception cref="OperationOAuthException">Thrown if the request could not be authenticated.</exception>
        /// <exception cref="OperationRequestException">Thrown if the API request fails.</exception>
        /// <exception cref="OperationResponseParsingException">Thrown if the response could not be parsed.</exception>
        public async Task Request(string accessToken, IOperationsPostRequest request)
        {
            string requestEndpoint = request.GetEndpointUri();

            using UnityWebRequest webRequest = UnityWebRequest.Post(requestEndpoint, string.Empty, "application/json");
            await ComputeRequest(accessToken, webRequest);

            ConfirmResponse(webRequest);
        }

        /// <summary>
        /// Sets up, sends and verifies a <see cref="UnityWebRequest"/>.
        /// </summary>
        /// <param name="accessToken">The OAuth Access Token to use for authentication.</param>
        /// <param name="webRequest">The <see cref="UnityWebRequest"/> to compute.</param>
        /// <exception cref="OperationOAuthException">Thrown if the request could not be authenticated.</exception>
        /// <exception cref="OperationRequestException">Thrown if the request was not successful.</exception>
        private async Task ComputeRequest(string accessToken, UnityWebRequest webRequest)
        {
            SetupWebRequest(accessToken, webRequest);

            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            CheckWebRequest(webRequest);
        }

        /// <summary>
        /// Sets up the <see cref="UnityWebRequest"/> with API keys and disposal settings.
        /// </summary>
        /// <param name="accessToken">The OAuth Access Token to use for authentication.</param>
        /// <param name="webRequest">The request to set up.</param>
        /// <exception cref="OperationOAuthException">Thrown if the request could not be authenticated.</exception>
        private void SetupWebRequest(string accessToken, UnityWebRequest webRequest)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new OperationOAuthException(webRequest, "The provided access token was empty!");

            webRequest.SetRequestHeader("Authorization", $"Bearer {accessToken}");

            webRequest.disposeUploadHandlerOnDispose = true;
            webRequest.disposeDownloadHandlerOnDispose = true;
        }

        /// <summary>
        /// Checks the given <see cref="UnityWebRequest"/> for errors.
        /// </summary>
        /// <param name="webRequest">The request to check.</param>
        /// <exception cref="OperationRequestException">Thrown if the request was not successful.</exception>
        private void CheckWebRequest(UnityWebRequest webRequest)
        {
            if (webRequest.result != UnityWebRequest.Result.Success)
                throw new OperationRequestException(webRequest);

            Debug.Log("Operations API computation succeeded.");
        }

        /// <summary>
        /// Checks if the downloaded response was correct.
        /// </summary>
        /// <typeparam name="TResponse">The expected response type.</typeparam>
        /// <param name="request">The web request.</param>
        /// <exception cref="OperationResponseParsingException">Thrown if the response could not be parsed.</exception>
        private TResponse ConfirmResponse<TResponse>(UnityWebRequest request)
        {
            try
            {
                return JsonConvert.DeserializeObject<TResponse>(request.downloadHandler?.text);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to confirm successful API response:\n{e}");
                throw new OperationResponseParsingException(request, e);
            }
        }

        /// <summary>
        /// Checks if the downloaded response was empty, as to be expected of some endpoints.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <exception cref="OperationResponseParsingException">Thrown if the response was not empty.</exception>
        private void ConfirmResponse(UnityWebRequest request)
        {
            if (!string.IsNullOrEmpty(request.downloadHandler?.text) && request.downloadHandler.text.Trim() != EmptyJsonObject)
            {
                Debug.LogError($"Failed to confirm successful API response:\n{request.downloadHandler?.text}");
                throw new OperationResponseParsingException(request);
            }
        }
    }
}

