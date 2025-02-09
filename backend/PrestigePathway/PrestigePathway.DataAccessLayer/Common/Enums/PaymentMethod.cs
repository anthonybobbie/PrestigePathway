using System.Runtime.Serialization;

namespace PrestigePathway.DataAccessLayer.Common.Enums
{
    public enum PaymentMethod
    {
        [EnumMember(Value = "Cash")]
        Cash,
        [EnumMember(Value = "Mobile Money")]
        MobileMoney,
        [EnumMember(Value = "Credit Card")]
        CreditCard,  
        [EnumMember(Value = "Bank Transfer")]
        BankTransfer,
        [EnumMember(Value = "Paypal")]
        Paypal
    }
}
