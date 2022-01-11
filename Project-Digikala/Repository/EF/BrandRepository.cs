using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
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

        public async Task DeleteAsync(int id)
        {
            Brand br =await Context.Brands.FindAsync(id);
            Context.Brands.Remove(br);
        }

        public async Task<Brand> FindAsync(int id)
        {
            var br= await Context.Brands.Include(o=>o.Creator).Where(b => b.Id == id).ToAsyncEnumerable().SingleOrDefault();
            return br;
        }

        public async Task saveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brand>> SearchAsync(string title, int? id, State? state)
        {
           var Query=  await Context.Brands.Include(o => o.Creator).Include(o=>o.LastModifier).ToAsyncEnumerable().ToList();
           var brands=await Query.Where(b=>(b.Title==title || string.IsNullOrEmpty(title)) && (b.Id == id || id==null) && (b.state == state || state == null)).ToAsyncEnumerable().ToList();
            
            return brands;
        }

 

        public async Task Update(Brand brand)
        {
            var br=await Context.Brands.FindAsync(brand.Id);
            br.Id = brand.Id;
            br.Title = brand.Title;
            br.Slug = brand.Slug;
            br.LastModifier = brand.LastModifier;
            br.LastModifyDate = DateTime.Now;
            br.state=brand.state;
        }
    }
}