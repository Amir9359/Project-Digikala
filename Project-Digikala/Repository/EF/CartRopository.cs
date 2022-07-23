using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
using Project_Digikala.Models.Products.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Repository.EF
{
    public class CartRopository : ICartRopository
    {
        private ApplicationDbContext _Context;
        public CartRopository(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task Add(Cart cart)
        {
            await _Context.Cart.AddAsync(cart);
        }

        public async Task Add(CartItem cartItem)
        {
            await _Context.CartItem.AddAsync(cartItem);
        }

 
        public void DeletCartItems(List<CartItem> CartItems)
        {
            _Context.CartItem.RemoveRange(CartItems);
        }
 
        public async Task Delete(int cartItemId)
        {
            var cartItem = await _Context.CartItem.FindAsync(cartItemId);
            _Context.CartItem.Remove(cartItem);
        }

 
        public async Task DeleteCart(int cartId)
        {
            var Cart=  await _Context.Cart.FindAsync(cartId);
            _Context.Cart.Remove(Cart);
        }

 
        public async Task<Cart> Find(int cartid)
        {
            var cart = await _Context.Cart.FindAsync(cartid);
            return cart;
        }

        public async Task<Cart> Find(string customerid)
        {
            var cart = await _Context.Cart.Include(c => c.Operator)
                .Include(c => c.cartItems)
                .ThenInclude(i => i.ProductItems).ThenInclude(p => p.Product).SingleOrDefaultAsync(c => c.Operator.Id == customerid);
            return cart;
        }

        public async Task save()
        {
            await _Context.SaveChangesAsync();
        }

        public async Task<List<Cart>> search(string customeerId)
        {
            var carts = await _Context.Cart.Where(c => c.Operator.Id == customeerId)
               .Include(c => c.Operator).ToAsyncEnumerable().ToList();
            return carts;
        }

        public async Task Update(CartItem item)
        {
            var cartItem = await _Context.CartItem.FindAsync(item.Id);
            var Quantity = item.Quantity + cartItem.Quantity;
            cartItem.Id = item.Id;
            cartItem.Quantity = Quantity;

            _Context.CartItem.Update(cartItem);
            _Context.Entry(cartItem).Reference(c => c.Cart).IsModified = false;
            _Context.Entry(cartItem).Reference(c => c.ProductItems).IsModified = false;

        }
    }
}
