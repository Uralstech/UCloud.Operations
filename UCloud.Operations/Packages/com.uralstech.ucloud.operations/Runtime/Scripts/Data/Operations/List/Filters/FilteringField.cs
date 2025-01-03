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
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// The field to compare with a given value to filter the operations.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilteringField
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None,

        /// <summary>
        /// Filter by the service which an operation belongs to.
        /// </summary>
        [EnumMember(Value = "serviceName")]
        ServiceName,

        /// <summary>
        /// Filter by the operation's start time.
        /// </summary>
        [EnumMember(Value = "startTime")]
        StartTime,

        /// <summary>
        /// Filter by the operation's status.
        /// </summary>
        [EnumMember(Value = "status")]
        Status,
    }
}
