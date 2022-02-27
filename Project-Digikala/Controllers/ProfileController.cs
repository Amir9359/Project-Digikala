using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Digikala.Models;
using Project_Digikala.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Controllers
{
    public class ProfileController : Controller
    {
        private IAddressRepository _AddressRepository;
        private UserManager<@operator> _UserManager;
        public ProfileController(IAddressRepository AddressRepository, UserManager<@operator> UserManager)
        {
            _UserManager = UserManager;
            _AddressRepository = AddressRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> save(string province, string city, string address, string tel)
        {
            var customer = await _UserManager.FindByNameAsync(User.Identity.Name);
            await _AddressRepository.Add(new Address
            {
                city = city,
                Province = province,
                Location = address,
                Phone = tel,
                Customer = customer
            });
            await _AddressRepository.save();
            return View("Index");
        }
    }
}
