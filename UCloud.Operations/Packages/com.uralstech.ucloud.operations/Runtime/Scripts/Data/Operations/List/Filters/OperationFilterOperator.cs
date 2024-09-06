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
