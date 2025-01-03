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
using Newtonsoft.Json.Serialization;

namespace Uralstech.UCloud.Operations.Generic
{
    /// <summary>
    /// This resource represents a long-running operation that is the result of a network API call.
    /// </summary>
    /// <typeparam name="TMetadata">The type of the operation's metadata.</typeparam>
    /// <typeparam name="TResponse">The type of the operation's response.</typeparam>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Operation<TMetadata, TResponse>
    {
        /// <summary>
        /// The server-assigned name, which is only unique within the same service that originally returns it.
        /// </summary>
        /// <remarks>
        /// If you use the default HTTP mapping, the name should be a resource name ending with operations/{unique_id}.
        /// </remarks>
        public string Name;

        /// <summary>
        /// Service-specific metadata associated with the operation. It typically contains progress information and common metadata such as create time.
        /// </summary>
        /// <remarks>
        /// Service-specific metadata associated with the operation. It typically contains progress information and common metadata such as create time.
        /// </remarks>
        public TMetadata Metadata = default;

        /// <summary>
        /// If the value is false, it means the operation is still in progress.
        /// If true, the operation is completed, and either <see cref="Error"/> or <see cref="Response"/> is available.
        /// </summary>
        public bool Done;

        /// <summary>
        /// The error result of the operation in case of failure or cancellation.
        /// </summary>
        public OperationStatus Error = null;

        /// <summary>
        /// The normal response of the operation in case of success. If the original method returns no data on success, such as Delete, the response is google.protobuf.Empty.
        /// </summary>
        /// <remarks>
        /// If the original method is standard Get/Create/Update, the response should be the resource. For other methods, the response should have the type XxxResponse,<br/>
        /// where Xxx is the original method name. For example, if the original method name is TakeSnapshot(), the inferred response type is TakeSnapshotResponse.
        /// </remarks>
        public TResponse Response = default;
    }
}
