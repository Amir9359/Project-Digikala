using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Brands
{
   public interface IBrandRepository
    {
        Task AddAsync(Brand brand);
        void Update(Brand brand);
        Task DeleteAsync(Brand brand);
        Task<IEnumerable<Brand>> SearchAsync();
        Task<Brand> FindAsync(int id);
        Task saveAsync();
    }
}
