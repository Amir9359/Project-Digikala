using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products
{
   public  interface IProductRepository
    {
        Task AddAsync(Product Product);
        void Update(Product Product);
        Task DeleteAsync(int Id);
        Task<Product> FindAsync(int id);
        Task<IEnumerable<Product>> SearchAsync(int? id , string PrimaryTitle);
        Task saveAsync();
    }
}
