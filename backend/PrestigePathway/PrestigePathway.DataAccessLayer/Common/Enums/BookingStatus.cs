using System.Runtime.Serialization;

namespace PrestigePathway.DataAccessLayer.Common.Enums
{
    public enum BookingStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Confirmed")]
        Confirmed,
        [EnumMember(Value = "Completed")]
        Completed,
        [EnumMember(Value = "Cancelled")]
        Cancelled
    }
}
