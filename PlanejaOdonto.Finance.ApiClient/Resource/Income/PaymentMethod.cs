using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PlanejaOdonto.Finance.ApiClient.Resource.Income
{
    public enum PaymentMethod
    {
        [Description("Cartão de Crédito")]
        CreditCard = 1,

        [Description("Pix")]
        Pix = 2,

        [Description("Dinheiro")]
        Cash = 3,

        [Description("Cheque")]
        Check = 4,

    }
}
