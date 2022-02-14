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
    public class SpecificationRepository : ISpecificationRepository
    {
       private ApplicationDbContext context;
        public SpecificationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Specification Specification)
        {
            await context.Specifications.AddAsync(Specification);
        }

        public async Task DeleteAsync(int id)
        {
            var specification = await context.Specifications.FindAsync(id);
            context.Specifications.Remove(specification);
        }

        public async Task<Specification> FindAsync(int id)
        {
            var specification = await context.Specifications.Include(s=>s.SpecificationGroup).FirstOrDefaultAsync(s=>s.Id==id);
            return specification;

        }

        public async Task saveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Specification>> SearchAsync(int? id, string title, State state)
        {
            var query = await context.Specifications.Include(s => s.SpecificationGroup).Include(s => s.Creator).Include(s => s.LastModifier).ToAsyncEnumerable().ToList();
            var search = query.Where(p => (p.Id == id || id == null) && (p.Title == title || title.CheckStringIsnull()));
            return search;
        }

        public async Task UpdateAsync(Specification Specification)
        {
            var Specifications = await context.Specifications.Include(s => s.SpecificationGroup).FirstOrDefaultAsync(s => s.Id == Specification.Id);
            Specifications.Title = Specification.Title;
            Specifications.state = Specification.state;
            Specifications.LastModifier = Specification.LastModifier;
            Specifications.LastModifyDate = Specification.LastModifyDate;

            context.Specifications.Update(Specifications);

            context.Entry(Specifications).Reference(s => s.SpecificationGroup).IsModified = false;
            context.Entry(Specifications).Reference(s => s.Creator).IsModified = false;
        }
    }
}
