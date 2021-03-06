﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.Products
{
    public class ProductTestRepository : IProductsRepository
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product() {ProductType = "Carpet", CostPerSquareFoot = 2.25M, LaborCostPerSquareFoot = 2.10M}
            };
        }
    }
}
