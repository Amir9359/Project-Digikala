﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Digikala.Models.Order;
using Project_Digikala.Models.Products;
using Project_Digikala.Models.Products.Brands;
using Project_Digikala.Models.Products.Cart;
using Project_Digikala.Models.Products.Groups;
using Project_Digikala.Models.Products.KeyPoints;
using Project_Digikala.Models.Products.ProductItem;
using Project_Digikala.Models.Products.Specifications;
using Project_Digikala.Models.Products.Tags;
using Project_Digikala.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Digikala.Models
{
    public class ApplicationDbContext : IdentityDbContext<@operator>
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<keypoint> keypoints { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagValue> TagValues { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<SpecificationValue> SpecificationValues { get; set; }
        public DbSet<SpecificationGroup> SpecificationGroups { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ItemTagValue> ItemTagValues { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Order.Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ItemTagValue>().HasKey(sc => new { sc.ProductItemId, sc.TagValueId });
            base.OnModelCreating(builder);
        }
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<@operator> Usermanager = serviceProvider.GetRequiredService<UserManager<@operator>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];
            if (await Usermanager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                @operator user = new @operator
                {
                    UserName = username,
                    Email = email
                };
                IdentityResult result = await Usermanager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await Usermanager.AddToRoleAsync(user, role);
                }
            }

        }
    }
}
