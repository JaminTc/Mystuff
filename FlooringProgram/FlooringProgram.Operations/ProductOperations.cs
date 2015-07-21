using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data.Products;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Operations
{
    public class ProductOperations
    {
        public bool IsAllowedProduct(string material)
        {
            IProductsRepository repository = ProductRepositoryFactory.GetProductsRepository();
            var allProducts = repository.GetProducts();

            return allProducts.Any(t => t.ProductType == material);
        }

        public Product GetProductFor(string material)
        {
            IProductsRepository repository = ProductRepositoryFactory.GetProductsRepository();
            var allProducts = repository.GetProducts();

            return allProducts.FirstOrDefault(t => t.ProductType == material);
        }

        public IProductsRepository GetProductRepositoryFactory()
        {
            var productsRepository = ProductRepositoryFactory.GetProductsRepository();
            return productsRepository;
        }
    }
}
