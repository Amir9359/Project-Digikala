using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Order
{
    public enum  PayState:byte
    {
        [Description("پرداخت شده")]
        Paied=1,
        [Description("پرداخت نشده")]
        UnPaied =2
    }
}
