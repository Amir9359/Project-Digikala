using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Specifications
{
    public interface ISpecificationGroupRepository
    {
        Task AddAsync(SpecificationGroup Specification);
        Task DeleteAsync(int id);
        Task UpdateAsync(SpecificationGroup Specification);
        Task<SpecificationGroup> FindAsync(int id);
        Task<IEnumerable<SpecificationGroup>> SearchAsync(int? id, string title, State? state);
        Task<List<SpecificationGroup>> SearchAsync(int groupid);

        Task saveAsync();
    }
}
