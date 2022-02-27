using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using Project_Digikala.Models.Order;
using Project_Digikala.Models.Products.Cart;
using Project_Digikala.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.Models.Products.ProductItem;
using Project_Digikala.InfraStructure;

namespace Project_Digikala.Controllers
{
    public class OrderController : Controller
    {
        private ICartRopository _CartRopo;
        private UserManager<@operator> _UserManager;
        private IAddressRepository _AddressRepo;
        private IOrderRepository _OrderRepo;
        private IProductItemRepository _ProductItemRepo;
        public OrderController(IProductItemRepository ProductItemRepo, ICartRopository CartRopo, IOrderRepository OrderRepo, UserManager<@operator> UserManager, IAddressRepository AddressRepo)
        {
            _UserManager = UserManager;
            _CartRopo = CartRopo;
            _AddressRepo = AddressRepo;
            _OrderRepo = OrderRepo;
            _ProductItemRepo = ProductItemRepo;
        }
        public async Task<IActionResult> Index()
        {
            //-------cart-----------
            var customer = await _UserManager.FindByNameAsync(User.Identity.Name);
            var cart = await _CartRopo.Find(customer.Id);
            ViewBag.TotalPrice = cart.cartItems.Sum(p => p.ProductItems.Price * p.Quantity).ToString("N0");

            //------------------Address--------------
            var Address = await _AddressRepo.Find(customer.Id);
            if (Address != null)
            {
                return View(Address);
            }
            else
            {
                return RedirectToAction("Index", "Profile");
            }
        }
        public async Task<IActionResult> Save(ShippingTypes shipping, PaymentTypes payment)
        {
            //------------cart-----------
            var customer = await _UserManager.FindByNameAsync(User.Identity.Name);
            var cart = await _CartRopo.Find(customer.Id);
            var TotalPrice = cart.cartItems.Sum(p => p.ProductItems.Price * p.Quantity);
            //-----------------------addOrder-----------------------
            var order = new Order
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                PaymentType = payment,
                shippingType = shipping,
                TotlaPrice = TotalPrice,
                PayState = PayState.UnPaied
            };

            switch (shipping)
            {
                case ShippingTypes.Pishtaz:
                    order.TotlaPrice += 10000;
                    break;
                case ShippingTypes.Tipax:
                    order.TotlaPrice += 8000;
                    break;
            }

            await _OrderRepo.Add(order);
            await _OrderRepo.save();

            var OrderItems = new List<OrderItems>();
            foreach (var cartItems in cart.cartItems)
            {
                OrderItems.Add(new Models.Order.OrderItems
                {
                    order = order,
                    Price = cartItems.ProductItems.Price,
                    ProductItem = cartItems.ProductItems,
                    Quantity = cartItems.Quantity

                });

            }
            await _OrderRepo.Add(OrderItems);
            await _OrderRepo.save();

            //-----------DeletCartInformation-------------
            _CartRopo.DeletCartItems(cart.cartItems);
            await _CartRopo.save();

            await _CartRopo.DeleteCart(cart.ID);
            await _CartRopo.save();

            //-------------Update Product Quantity-----------
            var Pitems = new List<ProductItem>();
            foreach (var item in order.OrderItems)
            {
                Pitems.Add(new ProductItem
                {
                    Quantity = (byte)item.Quantity,
                    Id = item.ProductItem.Id
                });
            }
            await _ProductItemRepo.Update(Pitems);
            await _ProductItemRepo.save();

            return new RedirectResult($"/Order/Detail/{order.Id}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">شناسه سفارش</param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int id)
        {
            var customer = await _UserManager.FindByNameAsync(User.Identity.Name);
            var Order = await _OrderRepo.Find(id);
            ViewBag.address = await _AddressRepo.Find(customer.Id);
            return View(Order);
        }
        public async Task<IActionResult> SavePayment(int id, string paynumber, string payDate)
        {
            await _OrderRepo.Update(id, paynumber, payDate);
            await _OrderRepo.save();

            return new RedirectResult($"/Order/Detail/{id}");
        }
    }
}
