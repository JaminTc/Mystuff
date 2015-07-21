using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.Orders
{
    public class OrderTestRepository : IOrdersRepository
    {
        public List<Models.Orders> GetOrders(string orderDate)
        {
            return new List<Models.Orders>()
            {
                new Models.Orders() {OrderNumber = 1 , CustomerName = "Joe Dirt", State = "MN", TaxRate = 0.06m, ProductType = "Carpet", Area = 100, CostPerSquareFoot  = 2.21m, LaborCostPerSquareFoot = 1.50m, MaterialCost = 221.00m, LaborCost = 150.00m, Tax = 15.00m, Total = 386.00m}
            };
        }

        public void SaveOrder(List<Models.Orders> orders, string path)
        {

        }
    }
}
