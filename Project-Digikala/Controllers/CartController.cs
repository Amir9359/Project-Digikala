using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Cart;
using Project_Digikala.Models.Products.ProductItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Controllers
{
    public class CartController : Controller
{
        private UserManager<@operator> _UserManager;
        private ICartRopository _CartRopo;
        private IProductItemRepository _ProductItemRepo;
        public CartController(UserManager<@operator> UserManager, ICartRopository CartRopo,IProductItemRepository ProductItemRepo)
        {
            _UserManager = UserManager;
            _CartRopo = CartRopo;
            _ProductItemRepo = ProductItemRepo;
        }
    public async Task<IActionResult> Index(int? productitemsid, int? count)
    {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Signin", "Account");
            }
            else 
            {
                var user = await _UserManager.FindByNameAsync(User.Identity.Name);
                var cart = await _CartRopo.Find(user.Id);
                if (productitemsid != null && count != null)
                {
                    var Pitem = await _ProductItemRepo.Find((int)productitemsid);
                    if (cart != null)
                    {
                        if (cart.cartItems.Any(c=>c.ProductItems.Id == productitemsid))
                        {
                            var cartItem = cart.cartItems.FirstOrDefault(c => c.ProductItems.Id == productitemsid);
                            await _CartRopo.Update(new CartItem
                            {
                                Id=cartItem.Id,
                                Quantity=(int)count
                            });
                            await _CartRopo.save();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            await _CartRopo.Add(new CartItem
                            {
                                Cart = cart,
                                ProductItems = Pitem,
                                Quantity = (int)count
                            });

                            await _CartRopo.save();

                            return RedirectToAction("Index");
                        }

                    }
                    else
                    {
                        var newcart = new Cart
                        {
                            Operator = user
                        };
                        await _CartRopo.Add(newcart);
                        await _CartRopo.save();

                        var cartfinal = await _CartRopo.Find(newcart.ID);
                        await _CartRopo.Add(new CartItem
                        {
                            Cart = cartfinal,
                            ProductItems = Pitem,
                            Quantity = (int)count
                        });

                        await _CartRopo.save();

                        var sCart = await _CartRopo.Find(user.Id);
                        return RedirectToAction("Index");
                    }
                    
                }
                else 
                {
                    var userN = await _UserManager.FindByNameAsync(User.Identity.Name);
                    var cartN = await _CartRopo.Find(userN.Id);
                    return View(cartN);
                }
            }
        
    }
    public async Task<IActionResult> Remove(int id)
    {
           await _CartRopo.Delete(id);
            await _CartRopo.save();
            return new RedirectResult("/Cart");
    }
}
}
