using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Order
{
    public enum ShippingTypes : byte
    {
        [Description("تایپاکس")]
        Tipax =1,
        [Description("پست پیشتاز")]
        Pishtaz =2
    }
}
