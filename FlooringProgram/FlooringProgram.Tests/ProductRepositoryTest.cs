using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data.Products;
using FlooringProgram.Models.Interfaces;
using NUnit.Framework;

namespace FlooringProgram.Tests
{
        [TestFixture]
        class ProductRepositoryTest
        {
            [Test]
            public void ReadDataFile()
            {
                IProductsRepository repository = new ProductTestRepository();
                var product = repository.GetProducts();

                Assert.AreNotEqual(0, product.Count);
            }

            [Test]
            public void CorrectDataLoaded()
            {
                IProductsRepository repository = new ProductFileRepository();
                var products = repository.GetProducts();

                Assert.AreEqual("Carpet", products[0].ProductType);
                Assert.AreEqual(2.25M, products[0].CostPerSquareFoot);
                Assert.AreEqual(2.10M, products[0].LaborCostPerSquareFoot);
            }
        }
    }

