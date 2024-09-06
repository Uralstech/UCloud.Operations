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
