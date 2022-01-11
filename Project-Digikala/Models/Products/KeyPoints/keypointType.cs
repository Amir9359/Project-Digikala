using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.KeyPoints
{
    public enum keypointType:byte
    {
        [Description("مثبت")]
        Positive=1,

        [Description("منفی")]
        Negeticve = 2
    }
}
