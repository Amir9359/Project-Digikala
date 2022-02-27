using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public @operator Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotlaPrice { get; set; }
        public ShippingTypes shippingType { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}
