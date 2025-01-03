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

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// Gets the latest state of a long-running operation. Clients can use this method to poll the operation result at intervals as recommended by the API service.
    /// </summary>
    /// <remarks>
    /// Return type is <see cref="Operation"/> or <see cref="Generic.Operation{TMetadata, TResponse}"/>.
    /// </remarks>
    public class OperationGetRequest : IOperationsGetRequest
    {
        /// <summary>
        /// The resource name of the operation to get.
        /// </summary>
        public string OperationName;

        /// <inheritdoc/>
        public string BaseServiceUri { get; set; } = "https://servicemanagement.googleapis.com/v1";

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            return $"{BaseServiceUri}/{OperationName}";
        }

        /// <summary>
        /// Creates a new <see cref="OperationGetRequest"/>.
        /// </summary>
        /// <param name="operationName">The resource name of the operation to get.</param>
        public OperationGetRequest(string operationName)
        {
            OperationName = operationName;
        }
    }
}
