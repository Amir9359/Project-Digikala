using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Repository.EF
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Product product)
        {
            await context.AddAsync(product);
        }

        public async Task DeleteAsync(Product product)
        {
            Product p = await context.Products.FindAsync(product);
            context.Remove(p);
        }

        public async Task<Product> FindAsync(int id)
        {
           return await context.Products.Where(p => p.Id == id).ToAsyncEnumerable().SingleOrDefault();
        }

        public async Task saveAsync()
        {
           await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync()
        {
          var s= await  context.Products.Include(b => b.brand).ThenInclude(b => b.Creator).Include(g => g.group).ThenInclude(g => g.Creator).ToAsyncEnumerable().ToList();
            return s;
        }

        public void Update(Product product)
        {
            context.Products.Update(product);
        }
    }
}
