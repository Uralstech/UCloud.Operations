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

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// An operand of a filtering condition. Only provide one field in each instance.
    /// </summary>
    public class OperationFilterConditionOperand
    {
        /// <summary>
        /// The field the condition applies to.
        /// </summary>
        /// <remarks>
        /// The <see cref="FilteringField.ServiceName"/> restriction must be at the top-level
        /// and can only be combined with other restrictions via the <see cref="OperationFilterOperator.And"/> logical operator.
        /// </remarks>
        public FilteringField Field = FilteringField.None;

        /// <summary>
        /// The service to filter an operation by.
        /// </summary>
        public string ServiceName = string.Empty;

        /// <summary>
        /// The starting time to filter an operation by.
        /// </summary>
        public DateTime? StartTime = null;

        /// <summary>
        /// The running status to filter an operation by.
        /// </summary>
        public OperationRunningStatus Status;

        /// <inheritdoc/>
        public override string ToString()
        {
            return this switch
            {
                { Field: not FilteringField.None } => JsonConvert.SerializeObject(Field)[1..^1],
                { StartTime: not null } => StartTime.Value.ToString("O"),
                { Status: not OperationRunningStatus.None } => JsonConvert.SerializeObject(Status)[1..^1],
                _ when !string.IsNullOrEmpty(ServiceName) => ServiceName,
                _ => throw new NullReferenceException($"Expected at least one field to set in instance of {nameof(OperationFilterConditionOperand)}")
            };
        }
    }
}
