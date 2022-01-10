using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products
{
    interface IProductRepository
    {
        Task AddAsync(Product group);
        void Update(Product group);
        Task DeleteAsync(Product group);
        Task<Product> FindAsync(int id);
        Task<IEnumerable<Product>> SearchAsync();
        Task saveAsync();
    }
}
