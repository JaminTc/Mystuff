using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.Products
{
    public class ProductRepositoryFactory
    {
        public static IProductsRepository GetProductsRepository()
        {
            switch (ConfigurationSettings.GetMode())
            {
                case "Prod":
                    return new ProductFileRepository();
                case "Test":
                    return new ProductTestRepository();
            }

            return null;
        }
    }
}
