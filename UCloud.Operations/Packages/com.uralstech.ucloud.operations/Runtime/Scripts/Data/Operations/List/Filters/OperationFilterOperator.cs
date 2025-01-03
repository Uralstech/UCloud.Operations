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
    /// The operators to compare filtering conditions.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationFilterOperator
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None,

        /// <summary>
        /// Equal to.
        /// </summary>
        [EnumMember(Value = "=")]
        EqualTo,

        /// <summary>
        /// Not equal to.
        /// </summary>
        [EnumMember(Value = "!=")]
        NotEqualTo,

        /// <summary>
        /// Greater than.
        /// </summary>
        [EnumMember(Value = ">")]
        GreaterThan,

        /// <summary>
        /// Less than.
        /// </summary>
        [EnumMember(Value = "<")]
        LessThan,

        /// <summary>
        /// Greater than or equal to.
        /// </summary>
        [EnumMember(Value = ">=")]
        GreaterThanOrEqualTo,

        /// <summary>
        /// Less than or equal to.
        /// </summary>
        [EnumMember(Value = "<=")]
        LessThanOrEqualTo,

        /// <summary>
        /// And. Joins two conditions together.
        /// </summary>
        [EnumMember(Value = " AND ")]
        And,

        /// <summary>
        /// Or. Joins two conditions together.
        /// </summary>
        [EnumMember(Value = " OR ")]
        Or,
    }
}
