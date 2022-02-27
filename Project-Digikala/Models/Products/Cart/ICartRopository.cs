using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Cart
{
    public interface ICartRopository
    {
        Task Add(Cart cart);
        Task Add(CartItem cartItem);
        Task<Cart> Find(int cartid);
        Task<Cart> Find(string customerid);
        Task<List<Cart>> search(string customeerId);
        Task Update(CartItem item);
        Task Delete(int cartItemId);
        Task DeleteCart(int cartId);
        void  DeletCartItems(List<CartItem> CartItems);
        Task save();
    }
}
