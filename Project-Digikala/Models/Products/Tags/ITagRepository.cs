using Project_Digikala.Models.Products.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Tags
{
    public interface ITagRepository
    {
        Task Add(Tag tag);
        Task Update(Tag tag);
        Task<Tag> Find(int id);
        Task<IEnumerable<Tag>> Search(int? id, string title);
        Task Delete(int id);
        Task Save();

    }
}
