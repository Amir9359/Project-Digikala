using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Order
{
   public interface IOrderRepository
    {
        Task Add(Order order);
        Task Add(List<OrderItems> orderItems);
        Task<Order> Find(int orderId);
        Task Update(int orderid, string FishNumber , string PayDate);
        Task save();
    }
}
