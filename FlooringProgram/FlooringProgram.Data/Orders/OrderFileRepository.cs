using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;



namespace FlooringProgram.Data.Orders
{
    public class OrderFileRepository : IOrdersRepository
    {
        public List<Models.Orders> GetOrders(string path)
        {

            List<Models.Orders> orders = new List<Models.Orders>();


            try
            {
                string[] data = File.ReadAllLines(path);
                for (int i = 1; i < data.Length; i++)
                {
                    string[] row = data[i].Split(',');

                    Models.Orders toAdd = new Models.Orders();
                    toAdd.OrderNumber = int.Parse(row[0]);
                    toAdd.CustomerName = row[1];
                    toAdd.State = row[2];
                    toAdd.TaxRate = decimal.Parse(row[3]);
                    toAdd.ProductType = row[4];
                    toAdd.Area = decimal.Parse(row[5]);
                    toAdd.CostPerSquareFoot = decimal.Parse(row[6]);
                    toAdd.LaborCostPerSquareFoot = decimal.Parse(row[7]);
                    toAdd.MaterialCost = decimal.Parse(row[8]);
                    toAdd.LaborCost = decimal.Parse(row[9]);
                    toAdd.Tax = decimal.Parse(row[10]);
                    toAdd.Total = decimal.Parse(row[11]);


                    orders.Add(toAdd);
                }
            }
            catch
            {
                ArgumentException ex = new ArgumentException("File is corrupt. Could not load.");
                Console.Write(ex.Message);
                Console.WriteLine(" You must choose another date.\n Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                string directory = @"Data\Error.txt";
                if (!File.Exists(directory))
                    File.CreateText(directory).Close();
                using (StreamWriter writer = new StreamWriter(directory, true))
                {
                    writer.WriteLine(ex + "\n" + DateTime.Now); //Message + "\n" + ex.StackTrace);
                }
                throw ex;
            }
            

            
            return orders;
        }
        
        public void SaveOrder(List<Models.Orders> order, string path)
        {
            string[] dataLine =
            {
                "OrderNumber, CustomerName, State, TaxRate, ProductType, Area, CostPerSquareFoot,LaborCostPerSquareFoot, MaterialCost, LaborCost, Tax, Total"
            };
            File.WriteAllLines(path, dataLine);

            foreach (var obj in order)
            {
                string[] orderInfo = new string[12];

                    orderInfo[0] = obj.OrderNumber.ToString();
                    orderInfo[1] = obj.CustomerName;
                    orderInfo[2] = obj.State;
                    orderInfo[3] = obj.TaxRate.ToString();
                    orderInfo[4] = obj.ProductType;
                    orderInfo[5] = obj.Area.ToString();
                    orderInfo[6] = obj.CostPerSquareFoot.ToString();
                    orderInfo[7] = obj.LaborCostPerSquareFoot.ToString();
                    orderInfo[8] = obj.MaterialCost.ToString();
                    orderInfo[9] = obj.LaborCost.ToString();
                    orderInfo[10] = obj.Tax.ToString();
                    orderInfo[11] = obj.Total.ToString();

                    string completeOrder = string.Join(",", orderInfo);
                    string[] newOrder = {completeOrder};
                File.AppendAllLines(path,newOrder);
            }
        }
    }
}
