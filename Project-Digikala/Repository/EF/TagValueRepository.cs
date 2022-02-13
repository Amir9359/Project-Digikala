using Microsoft.EntityFrameworkCore;
using Project_Digikala.InfraStructure;
using Project_Digikala.Models;
using Project_Digikala.Models.Products.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Repository.EF
{
    public class TagValueRepository : ITagValueRepository
    {
        private ApplicationDbContext context;
        public TagValueRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task Add(TagValue tag)
        {
            await context.TagValues.AddAsync(tag);
        }

        public async Task Delete(int id)
        {
            var tag = await context.TagValues.FindAsync(id);
            context.TagValues.Remove(tag);
        }

        public async Task<TagValue> Find(int id)
        {
            return await context.TagValues.Include(t => t.Tag).Include(t => t.Creator).Include(t => t.LastModifier).FirstOrDefaultAsync(t => t.Id == id);

        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TagValue>> Search(int? id, string title ,int tagid)
        {
            var query = await context.TagValues.Include(t => t.Tag).Include(t => t.Creator).Include(t => t.LastModifier).ToAsyncEnumerable().ToList();
            var tags = query.Where(t => (t.Title == title || title.CheckStringIsnull()) && (t.Id == id || id == null) && (t.Tag.Id==tagid));
            return tags;
        }

        public async Task Update(TagValue tag)
        {
            var tg = await context.TagValues.Include(t => t.Tag).Include(t => t.Creator).Include(t => t.LastModifier).FirstOrDefaultAsync(t => t.Id == tag.Id);
            tg.Id = tag.Id;
            tg.Title = tag.Title;
            tg.State = tag.State;
            tg.LastModifier = tag.LastModifier;
            tg.LastModifyDate = tag.LastModifyDate;

            context.TagValues.Update(tg);
            context.Entry(tag).Property(p => p.CreateDate).IsModified = false;
            context.Entry(tag).Reference(p => p.Creator).IsModified = false;
            context.Entry(tag).Reference(p => p.LastModifier).IsModified = false;
            context.Entry(tag).Reference(p => p.Tag).IsModified = false;
        }
    }
}
