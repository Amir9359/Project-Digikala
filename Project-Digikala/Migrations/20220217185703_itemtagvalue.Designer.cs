﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Digikala.Models;

namespace ProjectDigikala.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220217185703_itemtagvalue")]
    partial class itemtagvalue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Project_Digikala.Models.operator", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Brands.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.Property<byte>("state");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Groups.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.Property<byte>("state");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.KeyPoints.keypoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Title");

                    b.Property<byte>("state");

                    b.Property<byte>("type");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.HasIndex("ProductId");

                    b.ToTable("keypoints");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<string>("Description");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<string>("PrimaryTitle");

                    b.Property<string>("SecondaryTitle");

                    b.Property<int>("brandid");

                    b.Property<int>("groupid");

                    b.Property<byte>("state");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.HasIndex("brandid");

                    b.HasIndex("groupid");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.ProductItem.ItemTagValue", b =>
                {
                    b.Property<int>("ProductItemId");

                    b.Property<int>("TagValueId");

                    b.Property<int?>("TagId");

                    b.HasKey("ProductItemId", "TagValueId");

                    b.HasIndex("TagId");

                    b.HasIndex("TagValueId");

                    b.ToTable("ItemTagValues");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.ProductItem.ProductItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<double?>("Discount");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<double>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<byte>("Quantity");

                    b.Property<byte>("state");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductItems");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Specifications.Specification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<int?>("SpecificationGroupId");

                    b.Property<string>("Title");

                    b.Property<byte>("state");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.HasIndex("SpecificationGroupId");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Specifications.SpecificationGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<int?>("GroupsId");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<string>("Title");

                    b.Property<byte>("state");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("GroupsId");

                    b.HasIndex("LastModifierId");

                    b.ToTable("SpecificationGroups");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Specifications.SpecificationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Value");

                    b.Property<int?>("specificationId");

                    b.Property<byte>("state");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.HasIndex("ProductId");

                    b.HasIndex("specificationId");

                    b.ToTable("SpecificationValues");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Tags.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<byte>("State");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Tags.TagValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatorId");

                    b.Property<string>("LastModifierId");

                    b.Property<DateTime?>("LastModifyDate");

                    b.Property<byte>("State");

                    b.Property<int?>("TagId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LastModifierId");

                    b.HasIndex("TagId");

                    b.ToTable("TagValues");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_Digikala.Models.operator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Brands.Brand", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Groups.Group", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.KeyPoints.keypoint", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.HasOne("Project_Digikala.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Product", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.HasOne("Project_Digikala.Models.Products.Brands.Brand", "brand")
                        .WithMany()
                        .HasForeignKey("brandid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_Digikala.Models.Products.Groups.Group", "group")
                        .WithMany()
                        .HasForeignKey("groupid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.ProductItem.ItemTagValue", b =>
                {
                    b.HasOne("Project_Digikala.Models.Products.ProductItem.ProductItem", "ProductItems")
                        .WithMany("ItemTagValues")
                        .HasForeignKey("ProductItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project_Digikala.Models.Products.Tags.Tag")
                        .WithMany("ItemTagValues")
                        .HasForeignKey("TagId");

                    b.HasOne("Project_Digikala.Models.Products.Tags.TagValue", "TagValues")
                        .WithMany("ItemTagValues")
                        .HasForeignKey("TagValueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.ProductItem.ProductItem", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.HasOne("Project_Digikala.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Specifications.Specification", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.HasOne("Project_Digikala.Models.Products.Specifications.SpecificationGroup", "SpecificationGroup")
                        .WithMany("Specifications")
                        .HasForeignKey("SpecificationGroupId");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Specifications.SpecificationGroup", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.Products.Groups.Group", "Groups")
                        .WithMany()
                        .HasForeignKey("GroupsId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Specifications.SpecificationValue", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.HasOne("Project_Digikala.Models.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Project_Digikala.Models.Products.Specifications.Specification", "specification")
                        .WithMany()
                        .HasForeignKey("specificationId");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Tags.Tag", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");
                });

            modelBuilder.Entity("Project_Digikala.Models.Products.Tags.TagValue", b =>
                {
                    b.HasOne("Project_Digikala.Models.operator", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Project_Digikala.Models.operator", "LastModifier")
                        .WithMany()
                        .HasForeignKey("LastModifierId");

                    b.HasOne("Project_Digikala.Models.Products.Tags.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId");
                });
#pragma warning restore 612, 618
        }
    }
}
