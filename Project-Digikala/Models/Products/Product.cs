﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Digikala.Models.Products.Brands;
using Project_Digikala.Models.Products.Groups;
using Project_Digikala.Models.Products.KeyPoints;


namespace Project_Digikala.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string PrimaryTitle { get; set; }
        public string SecondaryTitle { get; set; }
        public string Description { get; set; }
        public Brand brand { get; set; }
        public Group group { get; set; }
        public keypoint state { get; set; }

        public @operator Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public @operator LasrModifier { get; set; }
        public DateTime LasteModifyDate { get; set; }
    }
}
