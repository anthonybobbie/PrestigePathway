using System.Runtime.Serialization;

namespace PrestigePathway.DataAccessLayer.Common.Enums
{
    public enum PaymentMethod
    {
        [EnumMember(Value = "Cash")]
        Cash,
        [EnumMember(Value = "MobileMoney")]
        MobileMoney,
        [EnumMember(Value = "CreditCard")]
        CreditCard,  
        [EnumMember(Value = "BankTransfer")]
        BankTransfer,
        [EnumMember(Value = "Paypal")]
        Paypal,
        [EnumMember(Value = "DebitCard")]
        DebitCard
    }
}
