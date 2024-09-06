namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// Conditions to filter operations by.
    /// </summary>
    public class OperationFilterConditions
    {
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
            return Operator == OperationFilterOperator.None
                ? OperandA.ToString()
                : $"{OperandA}{Operator}{OperandB}";
        }
    }
}
