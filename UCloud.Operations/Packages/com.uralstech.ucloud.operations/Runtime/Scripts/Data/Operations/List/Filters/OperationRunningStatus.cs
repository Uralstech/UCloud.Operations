using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Uralstech.UCloud.Operations
{
    /// <summary>
    /// The running status of an operation to filter by.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationRunningStatus
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None,

        /// <summary>
        /// Filter by operations which are finished.
        /// </summary>
        [EnumMember(Value = "done")]
        Finished,

        /// <summary>
        /// Filter by operations which are ongoing.
        /// </summary>
        [EnumMember(Value = "in_progress")]
        Ongoing,

        /// <summary>
        /// Filter by operations which failed.
        /// </summary>
        [EnumMember(Value = "failed")]
        Failed,
    }
}
