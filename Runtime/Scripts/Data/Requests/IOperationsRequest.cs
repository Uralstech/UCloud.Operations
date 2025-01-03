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
    /// All google.longrunning API requests must inherit from this interface.
    /// </summary>
    public interface IOperationsRequest
    {
        /// <summary>
        /// The base endpoint URI for the request.
        /// </summary>
        /// <remarks>
        /// This may be a specific service endpoint which contains the operations.
        /// </remarks>
        public string BaseServiceUri { get; set; }

        /// <summary>
        /// Gets the URI to the API endpoint.
        /// </summary>
        /// <returns>The URI.</returns>
        public string GetEndpointUri();
    }
}
