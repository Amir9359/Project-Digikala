using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.KeyPoints
{
    public interface IkeypointRepository
    {
        Task AddAsync(keypoint keypoint);
        void Update(keypoint keypoint);
        Task<keypoint> FindAsync(int id);
        Task<IEnumerable< keypoint>> SearchAsync(string title,int? id,keypointType keypoint);
        Task SaveAsync();
        Task Delete(int id);

    }
}
