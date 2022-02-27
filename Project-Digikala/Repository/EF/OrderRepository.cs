using Microsoft.EntityFrameworkCore;
using Project_Digikala.InfraStructure;
using Project_Digikala.Models;
using Project_Digikala.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Repository.EF
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _Context;
        public OrderRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task Add(Order order)
        {
            await _Context.Orders.AddAsync(order);
        }

        public async Task Add(List<OrderItems> orderItems)
        {
            await _Context.OrderItems.AddRangeAsync(orderItems);
        }

        public async Task<Order> Find(int orderId)
        {
            var order = await _Context.Orders
               .Include(o => o.OrderItems)
               .ThenInclude(p=>p.ProductItem)
               .ThenInclude(p => p.Product)
               .Include(c => c.Customer)
               .FirstOrDefaultAsync(o => o.Id == orderId);
            return order;
        }

        public async Task save()
        {
            await _Context.SaveChangesAsync();
        }

        public async Task  Update(int orderid, string FishNumber, string PayDate)
        {
            var ord =await _Context.Orders.FindAsync(orderid);
            ord.FishNumber = FishNumber;
            ord.PayState = PayState.Paied;
            ord.PayDate = PayDate.ToMiladiDate();

            _Context.Entry(ord).Reference(c => c.Customer).IsModified = false;

        }
    }
}
