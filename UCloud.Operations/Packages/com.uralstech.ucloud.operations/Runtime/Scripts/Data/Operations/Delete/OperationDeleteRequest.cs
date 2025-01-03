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
    /// Deletes a long-running operation. This method indicates that the client is no longer interested in the operation result. It does not cancel the operation.
    /// </summary>
    public class OperationDeleteRequest : IOperationsDeleteRequest
    {
        /// <summary>
        /// The resource name of the operation to delete.
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
        /// Creates a new <see cref="OperationDeleteRequest"/>.
        /// </summary>
        /// <param name="operationName">The resource name of the operation to delete.</param>
        public OperationDeleteRequest(string operationName)
        {
            OperationName = operationName;
        }
    }
}
