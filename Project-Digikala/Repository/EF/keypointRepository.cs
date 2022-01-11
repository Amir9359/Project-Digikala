using Project_Digikala.Models;
using Project_Digikala.Models.Products.KeyPoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.InfraStructure;
using Microsoft.EntityFrameworkCore;

namespace Project_Digikala.Repository.EF
{
    public class keypointRepository : IkeypointRepository
    {
        private ApplicationDbContext context;
        public keypointRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(keypoint keypoint)
        {
            await context.keypoints.AddAsync(keypoint);
        }

        public async Task Delete(int id)
        {
            var Keypoint =await context.keypoints.FindAsync(id);
             context.keypoints.Remove(Keypoint);
        }

        public async Task<keypoint> FindAsync(int id)
        {
            return await context.keypoints.Include(p=>p.Product).FirstOrDefaultAsync(p=>p.Id==id); 
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
  
        }

        public async Task<IEnumerable<keypoint>>  SearchAsync(string title, int? id,keypointType keypoint)
        {
            var query =await context.keypoints.Include(p => p.Creator).Include(p => p.LastModifier).Include(p=>p.Product).ToAsyncEnumerable().ToList();
            return await query.
                Where(p=>( p.Product.Id == id || id == null)
                && (p.Title==title || string.IsNullOrEmpty(title))
                && (p.type == keypoint )).ToAsyncEnumerable().ToList();
        }

        public void Update(keypoint keypoint)
        {
            context.keypoints.Update(keypoint);
            context.Entry(keypoint).Property(p => p.CreateDate).IsModified = false;
            context.Entry(keypoint).Property(p => p.type).IsModified = false;

            context.Entry(keypoint).Reference(p => p.Creator).IsModified = false;
            context.Entry(keypoint).Reference(p => p.Product).IsModified = false;
        }
    }
}
