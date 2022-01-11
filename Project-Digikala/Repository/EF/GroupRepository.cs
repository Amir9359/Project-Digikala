using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Repository.EF
{
    public class GroupRepository : IGroupRepository
    {
        private ApplicationDbContext context;
        public GroupRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Group group)
        {
           await context.Groups.AddAsync(group);
        }

        public async Task DeleteAsync(int id)
        {
            Group g =  await context.Groups.FindAsync(id);
            context.Groups.Remove(g);
        }

        public async Task<Group> FindAsync(int id) 
        {
            var f= await context.Groups.Include(o=>o.Creator).Where(g=>g.Id==id).ToAsyncEnumerable().SingleOrDefault();
            return f;
        }

        public async Task saveAsync()
        {
          await  context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Group>> SearchAsync(string title, int? id, State? state)
        {
            var Query = await context.Groups.Include(o => o.Creator).Include(o => o.LastModifier).ToAsyncEnumerable().ToList();
            var Groups = await Query.Where(b => (b.Title == title || string.IsNullOrEmpty(title)) && (b.Id == id || id == null) && (b.state == state || state == null)).ToAsyncEnumerable().ToList();

            return Groups;
        }
        public async Task Update(Group group)
        {
            var grp= await context.Groups.FindAsync(group.Id);
            grp.Id = group.Id;
            grp.Title = group.Title;
            grp.Slug = group.Slug;
            grp.LastModifier = group.LastModifier;
            grp.LastModifyDate = DateTime.Now;
            grp.state = group.state;
        }
    }
}
