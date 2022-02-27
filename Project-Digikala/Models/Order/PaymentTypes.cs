using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Order
{
    public enum PaymentTypes : Byte
    {
        [Description("کارت به کارت")]
        CartToCart = 1,
        [Description("واریز به حساب")]
        Variz = 2,
        [Description("پرداخت آنلاین")]
        Online = 3
    }
}
