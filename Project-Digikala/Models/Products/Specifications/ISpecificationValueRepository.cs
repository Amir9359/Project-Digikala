using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Specifications
{
   public interface ISpecificationValueRepository
    {
        Task AddAsync(SpecificationValue Specificationvalue);
        Task DeleteAsync(int id);
        Task UpdateAsync(SpecificationValue Specificationvalue);
        Task<SpecificationValue> FindAsync(int id);
        Task<IEnumerable<SpecificationValue>> SearchAsync(int? id, string Value, State? state);
        Task saveAsync();
    }
}
