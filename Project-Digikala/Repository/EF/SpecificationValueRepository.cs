using Microsoft.EntityFrameworkCore;
using Project_Digikala.InfraStructure;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Repository.EF
{
    public class SpecificationValueRepository : ISpecificationValueRepository
    {
        private ApplicationDbContext context;
        public SpecificationValueRepository(ApplicationDbContext context)
        {
            this.context = context;

        }
        public async Task AddAsync(List<SpecificationValue> Specificationvalues)
        {
            await context.SpecificationValues.AddRangeAsync(Specificationvalues);
        }

        public async Task DeleteAsync(int id)
        {
            var specification = await context.SpecificationValues.FindAsync(id);
            context.SpecificationValues.Remove(specification);
        }

        public async Task<SpecificationValue> FindAsync(int id)
        {
            var specificationvalue = await context.SpecificationValues.Include(s => s.specification).FirstOrDefaultAsync(s => s.Id == id);
            return specificationvalue;
        }

        public async Task saveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SpecificationValue>> SearchAsync(int? id, string Value, State? state)
        {
            var query = await context.SpecificationValues.Include(s => s.specification).Include(s => s.Creator).Include(s => s.LastModifier).ToAsyncEnumerable().ToList();
            var search = query.Where(p => (p.Id == id || id == null) && (p.Value == Value || Value.CheckStringIsnull()) && (p.state ==state || state == null));
            return search;
        }

        public async Task UpdateAsync(SpecificationValue Specificationvalue)
        {
            var SpecificationValueN = await context.SpecificationValues.Include(s => s.specification).FirstOrDefaultAsync(s => s.Id == Specificationvalue.Id);
            SpecificationValueN.Value = Specificationvalue.Value;
            SpecificationValueN.state = Specificationvalue.state;
            SpecificationValueN.LastModifier = Specificationvalue.LastModifier;
            SpecificationValueN.LastModifyDate = Specificationvalue.LastModifyDate;

            context.SpecificationValues.Update(SpecificationValueN);

            context.Entry(SpecificationValueN).Reference(s => s.specification).IsModified = false;
            context.Entry(SpecificationValueN).Reference(s => s.Creator).IsModified = false;
        }
    }
}
