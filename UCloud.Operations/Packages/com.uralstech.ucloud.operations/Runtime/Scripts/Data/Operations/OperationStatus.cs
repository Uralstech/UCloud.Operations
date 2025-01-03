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

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// The <see cref="OperationStatus"/> type defines a logical error model that is suitable for different programming environments, including REST APIs and RPC APIs. It is used by gRPC.
    /// </summary>
    /// <remarks>
    /// Each <see cref="OperationStatus"/> message contains three pieces of data: error code, error message, and error details.
    /// </remarks>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class OperationStatus
    {
        /// <summary>
        /// The status code, which should be an enum value of google.rpc.Code.
        /// </summary>
        public int Code;

        /// <summary>
        /// A developer-facing error message, which should be in English.
        /// </summary>
        /// <remarks>
        /// Any user-facing error message should be localized and sent in the google.rpc.Status.details field, or localized by the client.
        /// </remarks>
        public string Message;

        /// <summary>
        /// A list of messages that carry the error details. There is a common set of message types for APIs to use.
        /// </summary>
        public ProtobufObject[] Details;
    }
}
