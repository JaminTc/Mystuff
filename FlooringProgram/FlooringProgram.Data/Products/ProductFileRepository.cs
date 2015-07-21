using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Models;

namespace FlooringProgram.Data.Products
{
    public class ProductFileRepository : IProductsRepository
    {
        public List<Product> GetProducts()
        {
            List<Product> materialList = new List<Product>();

            string[] data = File.ReadAllLines(@"Data\Orders\Products.txt");
            for (int i = 1; i < data.Length; i++)
            {
                string[] row = data[i].Split(',');

                Product toAdd = new Product();
                toAdd.ProductType = row[0];
                toAdd.CostPerSquareFoot = decimal.Parse(row[1]);
                toAdd.LaborCostPerSquareFoot = decimal.Parse(row[2]);

                materialList.Add(toAdd);
            }

            return materialList;
        }
    }
}
