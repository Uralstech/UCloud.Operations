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
    /// Requests metadata for an operation. Return type is <see cref="OperationsListResponse"/> or <see cref="Generic.OperationsListResponse{TOperation}"/>.
    /// </summary>
    public class OperationsListRequest : IOperationsGetRequest
    {
        /// <summary>
        /// The conditions for filtering the operations to list.
        /// </summary>
        public OperationFilterConditions Filters;

        /// <summary>
        /// The maximum number of <see cref="Operation"/>s to return (per page).
        /// </summary>
        /// <remarks>
        /// This method returns at most 100 operations per page.
        /// </remarks>
        public int MaxResponseOperations = 50;

        /// <summary>
        /// A page token from a previous <see cref="OperationsListRequest"/> call.
        /// </summary>
        public string PageToken = string.Empty;

        /// <inheritdoc/>
        public string BaseServiceUri { get; set; } = "https://servicemanagement.googleapis.com/v1";

        /// <inheritdoc/>
        public string GetEndpointUri()
        {
            string uri = Filters != null
                ? $"{BaseServiceUri}/operations?filter={Filters}&pageSize={MaxResponseOperations}"
                : $"{BaseServiceUri}/operations?pageSize={MaxResponseOperations}";

            if (!string.IsNullOrEmpty(PageToken))
                uri += $"&pageToken={PageToken}";
            return uri;
        }

        /// <summary>
        /// Creates a new <see cref="OperationsListRequest"/>.
        /// </summary>
        public OperationsListRequest() { }

        /// <summary>
        /// Creates a new <see cref="OperationsListRequest"/>.
        /// </summary>
        /// <param name="filters">The conditions for filtering the operations to list.</param>
        public OperationsListRequest(OperationFilterConditions filters)
        {
            Filters = filters;
        }
    }
}
