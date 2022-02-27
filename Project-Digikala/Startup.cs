using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Digikala.Models;
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
using Project_Digikala.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Users
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(Configuration["Data:DigiKala:ConnectionStrings"]));

            services.AddIdentity<@operator, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IkeypointRepository, keypointRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagValueRepository, TagValueRepository>();
            services.AddScoped<ISpecificationGroupRepository, SpecificationGroupRepository>();
            services.AddScoped<ISpecificationRepository, SpecificationRepository>();
            services.AddScoped<ISpecificationValueRepository, SpecificationValueRepository>();
            services.AddScoped<IProductItemRepository, ProductItemRepository>();
            services.AddScoped<ICartRopository, CartRopository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Admin/Account/Signin";
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();

            app.UseMvc(route=>
            {
                route.MapRoute(name: "MyArea", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                route.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

            });
            ApplicationDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}
