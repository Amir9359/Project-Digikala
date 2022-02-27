using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.ProductItem
{
    public interface IProductItemRepository
    {
        Task Add(ProductItem productItem);
        Task AddItemTagValue(List<ItemTagValue> ItemTagValues);
        Task MergeItemTagValue(List<ItemTagValue> ItemTagValues);
        Task Update(ProductItem productItem);
        Task Update(List<ProductItem>  productItem);
        Task Delete(int? id);
        Task<List<ProductItem>> search(int Productid);
        Task<ProductItem> Find(int id);
        Task save();
    }
}
