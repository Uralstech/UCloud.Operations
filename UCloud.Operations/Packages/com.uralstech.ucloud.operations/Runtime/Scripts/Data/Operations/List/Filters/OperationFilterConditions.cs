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
