using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
using Project_Digikala.Models.Products.ProductItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Repository.EF
{
    public class ProductItemRepository : IProductItemRepository
    {
        private ApplicationDbContext context;
        public ProductItemRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task Add(ProductItem productItem)
        {
            await context.ProductItems.AddAsync(productItem);
        }

        public async Task AddItemTagValue(List<ItemTagValue> ItemTagValues)
        {
            await context.ItemTagValues.AddRangeAsync(ItemTagValues);
        }

        public async Task Delete(int? id)
        {
            var productitem = await context.ProductItems.FindAsync(id);
            context.Remove(productitem);
        }

        public async Task<ProductItem> Find(int id)
        {
            var productitem = await context.ProductItems
                .Include(t=>t.Product)
                .Include(t => t.ItemTagValues)
                .ThenInclude((ItemTagValue i) => i.TagValues).ThenInclude(t => t.Tag).Where(p=>p.Id == id).FirstOrDefaultAsync();
            return productitem;
        }

        public async Task save()
        {
            await context.SaveChangesAsync();
        }

        public async Task<List<ProductItem>> search(int Productid)
        {
            var query = await context.ProductItems.Include(t => t.ItemTagValues).ThenInclude((ItemTagValue i)=>i.TagValues).ThenInclude(t=>t.Tag).Include(t => t.Product).Include(t => t.Creator).Include(t => t.LastModifier).ToAsyncEnumerable().ToList();
            var ProductItems = query.Where(t => t.Product.Id == Productid).ToList();
            return ProductItems;
        }

        public async Task Update(ProductItem productItem)
        {
            var pitem = await context.ProductItems.Include(t => t.Product).Where(p => p.Id == productItem.Id).FirstOrDefaultAsync();
            pitem.Id = productItem.Id;
            pitem.Price = productItem.Price;
            pitem.state = productItem.state;
            pitem.Quantity = productItem.Quantity;
            pitem.Discount = productItem.Discount;
            pitem.LastModifier = productItem.LastModifier;
            pitem.LastModifyDate = productItem.LastModifyDate;

            context.ProductItems.Update(pitem);
            context.Entry(productItem).Property(p => p.CreateDate).IsModified = false;
            context.Entry(productItem).Reference(p => p.Creator).IsModified = false;
            context.Entry(productItem).Reference(p => p.LastModifier).IsModified = false;
            context.Entry(productItem).Reference(p => p.Product).IsModified = false;
        }
    }
}
