using Microsoft.EntityFrameworkCore;
using Project_Digikala.Models;
using Project_Digikala.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Repository.EF
{
    public class AddressRepository : IAddressRepository
    {
        private ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Address address)
        {
            await _context.Addresses.AddAsync(address);
        }

        public async Task<Address> Find(string customerId)
        {
            var Address = await _context.Addresses.SingleOrDefaultAsync(c => c.Customer.Id == customerId);
            return Address;
        }

        public async Task save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
