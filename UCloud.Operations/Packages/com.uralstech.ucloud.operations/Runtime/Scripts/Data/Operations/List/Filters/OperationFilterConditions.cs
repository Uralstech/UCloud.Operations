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

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// Conditions to filter operations by.
    /// </summary>
    public class OperationFilterConditions
    {
        /// <summary>
        /// Is this object also the start of a parenthetical condition? If <see langword="true"/>, then a ( symbol is added to the start of this conditino.
        /// </summary>
        public bool IsStartOfParentheticalCondition = false;

        /// <summary>
        /// Is this object also the end of a parenthetical condition? If <see langword="true"/>, then a ) symbol is added to the end of this conditino.
        /// </summary>
        public bool IsEndOfParentheticalCondition = false;

        /// <summary>
        /// The Left-Hand-Side operand.
        /// </summary>
        public OperationFilterConditionOperand OperandA;

        /// <summary>
        /// The operator.
        /// </summary>
        public OperationFilterOperator Operator;

        /// <summary>
        /// The Right-Hand-Side operand.
        /// </summary>
        public OperationFilterConditions OperandB;

        /// <inheritdoc/>
        public override string ToString()
        {
            string expression = Operator == OperationFilterOperator.None
                ? OperandA.ToString()
                : $"{OperandA}{JsonConvert.SerializeObject(Operator)[1..^1]}{OperandB}";

            return (IsStartOfParentheticalCondition ? '(' : string.Empty) + expression + (IsEndOfParentheticalCondition ? ')' : string.Empty);
        }
    }
}
