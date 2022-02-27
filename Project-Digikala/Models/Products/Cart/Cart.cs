using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Cart
{
    public class Cart
    {
        public int ID { get; set; }
        public @operator Operator { get; set; }

        public List<CartItem> cartItems { get; set; }
    }
}
