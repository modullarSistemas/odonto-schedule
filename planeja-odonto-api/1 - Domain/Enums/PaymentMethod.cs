using System.ComponentModel;

namespace PlanejaOdonto.Api.Domain.Enums
{
    public enum PaymentMethod : byte
    {
        [Description("Cartão de Crédito")]
        CreditCard = 1,

        [Description("Dinheiro")]
        Cash = 2,

        [Description("Cheque")]
        Check = 3,

        [Description("Pix")]
        Pix = 4
    }
}