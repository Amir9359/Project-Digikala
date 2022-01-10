using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Groups
{
    interface IGroupRepository
    {
        Task AddAsync(Group group);
        void Update(Group group);
        Task DeleteAsync(Group group);
        Task<Group> FindAsync(int id);
        Task<IEnumerable<Group>> SearchAsync();
        Task saveAsync();
    }
}
