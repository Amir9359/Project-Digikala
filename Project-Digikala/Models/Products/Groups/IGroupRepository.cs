using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models.Products.Groups
{
    public interface IGroupRepository
    {
        Task AddAsync(Group group);
        Task Update(Group group);
        Task DeleteAsync(int id);
        Task<Group> FindAsync(int id);
        Task<IEnumerable<Group>> SearchAsync(string title, int? id, State? state);
        Task saveAsync();
    }
}
