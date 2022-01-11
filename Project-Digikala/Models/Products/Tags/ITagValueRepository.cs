using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Tags
{
   public interface ITagValueRepository
    {
        Task Add(TagValue tag);
        Task Update(TagValue tag);
        Task<TagValue> Find(int id);
        Task<IEnumerable<TagValue>> Search(int? id, string title);
        Task Delete(int id);
        Task Save();
    }
}
