using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
using Project_Digikala.Models.Products.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.InfraStructure;

namespace Project_Digikala.Repository.EF
{
    
    public class TagRepository : ITagRepository
    {
        private ApplicationDbContext context;
        public TagRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task Add(Tag tag)
        {
            await context.Tags.AddAsync(tag);
        }

        public async Task Delete(int id)
        {
            var tag = await context.Tags.FindAsync(id);
            context.Tags.Remove(tag);
        }

        public async Task<Tag> Find(int id)
        {
            return await context.Tags.Include(t => t.Creator).Include(t => t.LastModifier).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Save()
        {
           await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tag>> Search(int? id, string title)
        {
            var query = await context.Tags.Include(t => t.Creator).Include(t => t.LastModifier).ToAsyncEnumerable().ToList();
            var tags = query.Where(t => (t.Title == title || title.CheckStringIsnull()) && (t.Id == id || id == null));
            return tags;
        }

        public async Task Update(Tag tag)
        {
            var tg = await context.Tags.Include(t => t.Creator).Include(t => t.LastModifier).FirstOrDefaultAsync(t => t.Id == tag.Id);
            tg.Id = tag.Id;
            tg.Title = tag.Title;
            tg.State = tag.State;
            tg.LastModifier = tag.LastModifier;
            tg.LastModifyDate = tag.LastModifyDate;

            context.Tags.Update(tg);
            context.Entry(tg).Property(p => p.CreateDate).IsModified = false;
            context.Entry(tg).Reference(p => p.Creator).IsModified = false;
        }
    }
}
