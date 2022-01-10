using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
using Project_Digikala.Models.Products.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Repository.EF
{
    public class BrandRepository : IBrandRepository
    {
       private ApplicationDbContext Context;
        public BrandRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public async Task AddAsync(Brand brand)
        {
          await Context.AddAsync(brand);
        }

        public async Task DeleteAsync(Brand brand)
        {
            Brand br =await Context.Brands.FindAsync(brand);
             Context.Brands.Remove(br);
        }

        public async Task<Brand> FindAsync(int id)
        {
            var br= await Context.Brands.Where(b => b.Id == id).ToAsyncEnumerable().SingleOrDefault();
            return br;
        }

        public async Task saveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brand>> SearchAsync()
        {
            return await Context.Brands.Include(o => o.Creator).ToAsyncEnumerable().ToList();
        }

        public void Update(Brand brand)
        {
            Context.Brands.Update(brand);
        }
    }
}
