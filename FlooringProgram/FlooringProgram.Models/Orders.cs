using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Models
{
    
    public class Orders
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public void ShowNewOrder(List<Orders> newOrder)
        {
            foreach (var match in newOrder)
            {
                Console.WriteLine("");
                Console.WriteLine("Order Number: {0}", match.OrderNumber);
                Console.WriteLine("Customer Name: {0}", match.CustomerName);
                Console.WriteLine("Customer State: {0}", match.State);
                Console.WriteLine("State Tax Rate: {0}", match.TaxRate);
                Console.WriteLine("Product Type: {0}", match.ProductType);
                Console.WriteLine("Area: {0} sqFt", match.Area);
                Console.WriteLine("Cost per square foot: {0:c}", match.CostPerSquareFoot);
                Console.WriteLine("Labor cost per square foot: {0:c}", match.LaborCostPerSquareFoot);
                Console.WriteLine("Overall material cost: {0:c}", match.MaterialCost);
                Console.WriteLine("Overall Labor Cost: {0:c}", match.LaborCost);
                Console.WriteLine("Total Tax: {0:c}", match.Tax);
                Console.WriteLine("Total: {0:c}", match.Total);
                Console.WriteLine("");

            }
        }
    }
}
