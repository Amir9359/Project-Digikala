using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Brands
{
   public interface IBrandRepository
    {
        Task AddAsync(Brand brand);
        Task Update(Brand brand);
        Task DeleteAsync(int id);
        Task<IEnumerable<Brand>> SearchAsync(string title, int? id, State? state);
        Task<Brand> FindAsync(int id);
        Task saveAsync();
    }
}
