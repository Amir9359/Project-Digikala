using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
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

        public async Task DeleteAsync(Group group)
        {
            Group g =  await context.Groups.FindAsync(group);
            context.Groups.Remove(g);
        }

        public async Task<Group> FindAsync(int id) 
        {
            var f= await context.Groups.Where(g=>g.Id==id).ToAsyncEnumerable().SingleOrDefault();
            return f;
        }

        public async Task saveAsync()
        {
          await  context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Group>> SearchAsync()
        {
          return  await context.Groups.Include(o=>o.Creator).ToAsyncEnumerable().ToList();
        }

        public void Update(Group group)
        {
              context.Groups.Update(group);
        }
    }
}
