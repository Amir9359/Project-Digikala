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
    public class SpecificationGroupRepository : ISpecificationGroupRepository
    {
        private ApplicationDbContext context;
        public SpecificationGroupRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(SpecificationGroup Specification)
        {
            await context.SpecificationGroups.AddAsync(Specification);

        }

        public async Task DeleteAsync(int id)
        {
            var SpecificationGroups = await context.SpecificationGroups.FindAsync(id);
            var specifications = await context.Specifications.Where(s => s.SpecificationGroup.Id == id).ToAsyncEnumerable().ToList();
            if (specifications !=null )
            {
                context.Specifications.RemoveRange(specifications);
            }
            context.SpecificationGroups.Remove(SpecificationGroups);
        }

        public async Task<SpecificationGroup> FindAsync(int id)
        {
            var SpecificationGroup = await context.SpecificationGroups.Include(s =>s.Groups ).FirstOrDefaultAsync(s => s.Id == id);
            return SpecificationGroup;
        }

        public async Task saveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SpecificationGroup>> SearchAsync(int? id, string title, State? state)
        {
            var query =await context.SpecificationGroups.Include(s => s.Groups).Include(s => s.Creator).Include(s => s.LastModifier).ToAsyncEnumerable().ToList();
            var search = query.Where(p => (p.Groups.Id == id || id == null) && (p.Title == title || title.CheckStringIsnull()));
            return search;
        }
        public async Task<List<SpecificationGroup>> SearchAsync(int groupid)
        {
            var query =await context.SpecificationGroups.Include(s => s.Groups).Include(s=>s.Specifications).Include(s => s.Creator).Include(s => s.LastModifier).ToAsyncEnumerable().ToList();
            var search = query.Where(p => (p.Groups.Id == groupid )).ToList();
            return search;
        }

        public async Task UpdateAsync(SpecificationGroup SpecificationGroup)
        {
            var Specification = await context.SpecificationGroups.Include(s => s.Groups).FirstOrDefaultAsync(s => s.Id == SpecificationGroup.Id);
            Specification.Title = SpecificationGroup.Title;
            Specification.LastModifier = SpecificationGroup.LastModifier;
            Specification.LastModifyDate= SpecificationGroup.LastModifyDate;
            Specification.state= SpecificationGroup.state;

              context.SpecificationGroups.Update(Specification);

            context.Entry(Specification).Reference(s => s.Groups).IsModified = false;
            context.Entry(Specification).Reference(s => s.Creator).IsModified = false;
        }
    }
}
