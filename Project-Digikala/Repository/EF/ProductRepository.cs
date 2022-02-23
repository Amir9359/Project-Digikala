using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.InfraStructure;

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

        public async Task DeleteAsync(int id)
        {
            Product p = await context.Products.FindAsync(id);
            context.Remove(p);
        }

        public async Task<Product> FindAsync(int id)
        {
            return await context.Products.Include(b => b.group).Where(p => p.Id == id).ToAsyncEnumerable().SingleOrDefault();
        }
        

        public async Task<Product> ProductDetailAsync(int Productid)
        {
            return await context.Products.Include(b => b.brand).Include(g => g.group).ThenInclude(sg => sg.SpecificationGroups)
                .ThenInclude(s => s.Specifications).Include(item=>item.ProductItems).ThenInclude(s => s.ItemTagValues)
                .ThenInclude(s => s.TagValues).ThenInclude(s => s.Tag).Where(p => p.Id == Productid).ToAsyncEnumerable().SingleOrDefault();
        }

        public async Task saveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> SearchAsync(int? id, string PrimaryTitle)
        {
            var query = await context.Products.Include(b => b.brand).Include(b => b.Creator).Include(g => g.group).Include(g => g.LastModifier)
            .Where(p => (p.Id == id || id == null) && (p.PrimaryTitle == PrimaryTitle || PrimaryTitle.CheckStringIsnull())).ToAsyncEnumerable().ToList();
            return query;
        }

        public async Task<IEnumerable<Product>> SearchAsync(string keyword, int? fromprice, int? toprice, int? brands, int[] specs)
        {
            var query = await context.Products.Include(b => b.brand).Include(g => g.group).Include(item => item.ProductItems).Include(s => s.SpecificationValues).ThenInclude(v => v.specification).ThenInclude(g => g.SpecificationGroup)
            .Where(p => ((p.PrimaryTitle.Contains(keyword) || p.SecondaryTitle.Contains(keyword) || p.group.Title.Contains(keyword) || p.brand.Title.Contains(keyword))
            && p.ProductItems.Any(c => (fromprice == null || c.Price >= fromprice) && (toprice == null || c.Price <= toprice))
            && (specs.Length == 0 || p.SpecificationValues.Any(s => specs.Contains(s.specification.Id)))
            && (brands == null || p.brand.Id == brands)
            )).ToAsyncEnumerable().ToList();
            return query;
        }

        public async Task<IEnumerable<Product>> SearchAsync(int Groupid)
        { 
            var query = await context.Products.Include(b => b.brand).Include(g => g.group).ThenInclude(s => s.SpecificationGroups).Include(item => item.ProductItems)
            .Where(p => (p.groupid == Groupid)).ToAsyncEnumerable().ToList();
            return query;
        }

        public void Update(Product product)
        {//اگر تنها اپدیت کنیم مقدار زمان ایجاد 000 0000 میشود  پس باید مقادیری که میخواهیم اپدیت شود تغییر دهیم
            context.Products.Update(product);
            context.Entry(product).Property(p => p.CreateDate).IsModified = false;
            context.Entry(product).Reference(p => p.Creator).IsModified = false;
        }
    }
}
