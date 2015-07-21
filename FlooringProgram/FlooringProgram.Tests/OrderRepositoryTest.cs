using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data.Orders;
using FlooringProgram.Models.Interfaces;
using NUnit.Framework;

namespace FlooringProgram.Tests
{
    [TestFixture]
    class OrdersRepositoryTest
    {
        [Test]
        public void ReadDataFile()
        {
            IOrdersRepository repository = new OrderTestRepository();
            var Orders = repository.GetOrders(@"Data\Orders\Orders_06012013.txt");

            Assert.AreNotEqual(0, Orders.Count);
        }

        [Test]
        public void CorrectDataLoaded()
        {
            IOrdersRepository repository = new OrderFileRepository();
            var orderList = repository.GetOrders(@"Data\Orders\Orders_06012013.txt");

            Assert.AreEqual(1, orderList[0].OrderNumber);
            Assert.AreEqual("Wise", orderList[0].CustomerName);
            Assert.AreEqual("OH", orderList[0].State);
            Assert.AreEqual(6.25M, orderList[0].TaxRate);
            Assert.AreEqual("Wood", orderList[0].ProductType);
            Assert.AreEqual(100.0M, orderList[0].Area);
            Assert.AreEqual(5.15M, orderList[0].CostPerSquareFoot);
            Assert.AreEqual(4.75M, orderList[0].LaborCostPerSquareFoot);
            Assert.AreEqual(515.00M, orderList[0].MaterialCost);
            Assert.AreEqual(475.00M, orderList[0].LaborCost);
            Assert.AreEqual(61.88M, orderList[0].Tax);
            Assert.AreEqual(1051.88M, orderList[0].Total);

        }
        //1,Wise,OH,6.25,Wood,100.00,5.15,4.75,515.00,475.00,61.88,1051.88
    }
}
