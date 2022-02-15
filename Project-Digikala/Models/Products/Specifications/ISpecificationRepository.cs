using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Specifications
{
    public interface ISpecificationRepository
    {
        Task AddAsync(Specification Specification);
        Task DeleteAsync(int id);
        Task UpdateAsync(Specification Specification);
        Task<Specification> FindAsync(int id);
        Task<IEnumerable<Specification>> SearchAsync(int? id, string title, State? state);
        Task saveAsync();
    }
}
