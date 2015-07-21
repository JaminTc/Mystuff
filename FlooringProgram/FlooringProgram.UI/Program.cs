using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using FlooringProgram.Data;
using FlooringProgram.Data.Orders;
using FlooringProgram.Data.Products;
using FlooringProgram.Data.TaxRates;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;

namespace FlooringProgram.UI
{
    internal class Program
    {
        private static Orders _orders = new Orders();
        private TaxRateOperations t = new TaxRateOperations();
        private ProductOperations p = new ProductOperations();
        private TotalCostOperations c = new TotalCostOperations();
        private OrderOperations o = new OrderOperations();

        private static void Main(string[] args)
        {
            Program p = new Program();
            string userSelectedOption = "";
            do
            {
                userSelectedOption = p.GetUserInput();
                switch (userSelectedOption)
                {
                    case "1":
                        p.DisplayOrders();
                        break;
                    case "2":
                        p.AddAnOrder();
                        break;
                    case "3":
                        p.EditAnOrder();
                        break;
                    case "4":
                        p.RemoveAnOrder();
                        break;
                    case "5":
                        break;                  
                    default:
                        Console.Clear();
                        Console.WriteLine("Thats not a valid choice. Please select again");
                        Console.WriteLine("");
                        break;
                }
            } while (userSelectedOption != "5");
        }



        private string GetOrderPath()
        {
            string path = "";
                bool doesDateExists = false;
                do
                {
                    Console.WriteLine("Enter a date to load orders from: (MMDDYYYY)");
                    string orderDate = Console.ReadLine();
                    path = (String.Format("Data\\Orders\\Orders_{0}.txt", orderDate));


                    if (!File.Exists(path) && ConfigurationSettings.GetMode() == "Prod")
                    {
                        Console.WriteLine("File does not exist. Push Enter to Continue");
                        Console.ReadLine();
                        Console.Clear();
                        return null;
                    }
                    else
                        doesDateExists = true;
                } while (!doesDateExists);
                return path;
           
        }

        private void AddAnOrder()
        {
            string today = DateTime.Today.ToString("MMddyyyy");
            string path = string.Format("Data\\Orders\\Orders_{0}.txt", today);
            if (!File.Exists(path))
                File.CreateText(path).Close();
            Console.Clear();
            bool isNameValid = false;
            bool isInputValid = false;
            bool isStateTrue = false;
            bool isProductTrue = false;
            bool isAreaTrue = false;
            string orCustomerName = "";
            decimal txRate = 0.00m;
            string productType = "";
            decimal orArea = 0.00m;
            decimal subTotal = 0.00m;
            string orState = "";
            var order = _orders;
            List<Orders> allOrders = null;
            try
            {
                allOrders = o.LoadInMem(path);
            }
            catch
            {
                return;
            }
            int orNumber;
            if (File.ReadLines(path).Count() == 0)
            {
                orNumber = 1;
            }
            else
                orNumber = File.ReadLines(path).Count();
            do
            {
                Console.Write("What is the new customer name?    ");
                orCustomerName = Console.ReadLine();
                if (orCustomerName == "")
                {
                    Console.WriteLine("Not a valid customer name. Must enter a name. \n Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }    
                else
                    isNameValid = true;
                Console.WriteLine("");
            } while (!isNameValid);
            do
            {

                Console.Write("In which state is your order located?    ");
                orState = Console.ReadLine().ToUpper();
                var txRateTru = t.IsAllowedState(orState);
                if (txRateTru)
                {
                    txRate = t.GetTaxRateFor(orState).TaxPercent;
                    isStateTrue = true;


                }
                else Console.WriteLine("Invalid Input");
                Console.WriteLine("");
            } while (!isStateTrue);
            do
            {
                Console.Write("What product would you like to buy?    ");
                var orType = Console.ReadLine();
                Console.WriteLine();
                var orProTrue = p.IsAllowedProduct(orType);
                if (orProTrue)
                {
                    productType = p.GetProductFor(orType).ProductType;
                    isProductTrue = true;
                }
                else Console.WriteLine("Invalid Input");
            } while (!isProductTrue);
            do
            {
                Console.Write("What area, in square feet, would you like to cover      ");
                var input = Console.ReadLine();
                Console.WriteLine("");
                bool isArea = Decimal.TryParse(input, out orArea);
                if (isArea)
                {
                    isAreaTrue = true;
                }
                else Console.WriteLine("Invalid Input");
            } while (!isAreaTrue);
            var orCostPerSquareFoot = p.GetProductFor(productType).CostPerSquareFoot;
            var orLaborCostPerSquareFoot = p.GetProductFor(productType).LaborCostPerSquareFoot;
            var orMaterialCost = c.MaterialTotalCalc(orArea, orCostPerSquareFoot);
            var orLaborCost = c.LaborTotalCalc(orArea, orLaborCostPerSquareFoot);
            subTotal = orLaborCost + orMaterialCost;
            var orTaxTotal = c.TaxTotalCalc(txRate, subTotal);
            var orTotal = c.TotalOrderCalc(subTotal, orTaxTotal);
            order.OrderNumber = orNumber;
            order.CustomerName = orCustomerName;
            order.State = orState;
            order.TaxRate = txRate;
            order.ProductType = productType;
            order.Area = orArea;
            order.CostPerSquareFoot = orCostPerSquareFoot;
            order.LaborCostPerSquareFoot = orLaborCostPerSquareFoot;
            order.MaterialCost = orMaterialCost;
            order.LaborCost = orLaborCost;
            order.Tax = orTaxTotal;
            order.Total = orTotal;

            allOrders.Add(order);
            var newOrder = allOrders.Where(x => x.OrderNumber == order.OrderNumber).ToList();
            _orders.ShowNewOrder(newOrder);

            do
            {
                Console.Write("Would you like to save this file? Y/N     ");
                var input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "Y":
                        o.SaveFromMem(allOrders, path);
                        isInputValid = true;
                        break;
                    case "N":
                        isInputValid = true;
                        break;
                    default:
                        Console.WriteLine("That is not a valid choice.  Please select Y or N.");
                        break;
                }
            } while (!isInputValid);


            Console.WriteLine();
            Console.Clear();
        }

        private void RemoveAnOrder()
        {
            Console.Clear();
            string path = GetOrderPath();
            if (path == null)
                return;
            Console.Clear();
            List<Orders> orderList = null;
            try
            {
                orderList = o.LoadInMem(path);
            }
            catch
            {
                return;
            }
            int numb1 = 0;
            bool isIntParse = false;
            bool isUserChoice = false;
            List<Orders> oldOrder = new List<Orders>();
            var min = orderList.Min(x => x.OrderNumber);
            var max = orderList.Max(x => x.OrderNumber);
            Orders orderToRemove = new Orders();
            do
            {

                Console.WriteLine("Select a order number to be removed");
                Console.Write("Order numbers {0} ----> {1}       ", min, max);
                var input = Console.ReadLine();
                bool toParse = int.TryParse(input, out numb1);
                if (numb1 >= min && numb1 <= max && toParse)
                {

                    oldOrder = orderList.Where(x => x.OrderNumber == numb1).ToList();
                    orderToRemove = orderList.FirstOrDefault(x => x.OrderNumber == numb1);
                    if (orderToRemove == null)
                    {
                        Console.WriteLine("That order does not exist. Order was previously removed");
                    } 
                    isIntParse = true;
                }
                else Console.WriteLine("Invalid Input");
                _orders.ShowNewOrder(oldOrder);
            } while (!isIntParse || orderToRemove == null);
            do
            {
                Console.WriteLine("Are you sure you want to remove Order? Y/N      ");
                var userChoice = Console.ReadLine().ToUpper();
                if (userChoice == "Y")
                {
                    orderList.RemoveAll(x => x.OrderNumber == numb1);
                    isUserChoice = true;
                    o.SaveFromMem(orderList, path);

                }
                else if (userChoice == "N")
                {
                    isUserChoice = true;
                }
                else Console.WriteLine("Invalid Input");
            } while (!isUserChoice);
            Console.Clear();
        }

        private void EditAnOrder()
        {
            Console.Clear();
            string path = GetOrderPath();
            if (path == null)
                return;
            Console.Clear();
            List<Orders> orderData = null;
            try
            {
                orderData = o.LoadInMem(path);
            }
            catch
            {
                return;
            }
            bool isIntParse = false;
            bool isStateTrue = false;
            bool isProductTrue = false;
            int numb1 = 0;
            decimal txRate = 0.00m;
            string changeProductType = "";
            decimal changeArea = 0.00m;
            decimal subTotal = 0.00m;
            string changeState = "";
            int changeOrderNumber = 0;
            string changeCustomerName = "";
            decimal changeCostPerSquareFoot = 0.00m;
            decimal changeLaborCostPerSquareFoot = 0.00m;
            decimal changeMaterialCost = 0.00m;
            decimal changeLaborCost = 0.00m;
            decimal changeTaxTotal = 0.00m;
            decimal changeTotal = 0.00m;
            List<Orders> listToEdit = new List<Orders>();
            Orders oldOrder = new Orders();
            var min = orderData.Min(x => x.OrderNumber);
            var max = orderData.Max(x => x.OrderNumber);
            _orders.ShowNewOrder(orderData);
            do
            {

                Console.WriteLine("Select a order number to be edited");
                Console.Write("Order numbers {0} ----> {1}       ",min,max);
                var input = Console.ReadLine();
                bool toParse = int.TryParse(input, out numb1);
                if (numb1 >= min && numb1 <= max && toParse)
                {

                    listToEdit = orderData.Where(x => x.OrderNumber == numb1).ToList();
                    _orders.ShowNewOrder(listToEdit);
                    oldOrder = listToEdit.FirstOrDefault(or => or.OrderNumber == numb1);
                    if (oldOrder == null)
                    {
                        Console.WriteLine("That order does not exist. Order was previously removed");

                    }
                    isIntParse = true;
                }
                else
                    Console.WriteLine("Invalid input");
            } while (!isIntParse || oldOrder == null);
            Console.Clear();

            changeOrderNumber = oldOrder.OrderNumber;
            Console.Write("Current customer name: {0}       ", oldOrder.CustomerName);
            changeCustomerName = Console.ReadLine();
            Console.WriteLine("");
            if (changeCustomerName == "")
            {
                changeCustomerName = oldOrder.CustomerName;
            }
            do
            {
                Console.Write("Current State: {0}      ", oldOrder.State);
                changeState = Console.ReadLine().ToUpper();
                Console.WriteLine("");
                var txRateTru = t.IsAllowedState(changeState);
                if (txRateTru)
                {
                    txRate = t.GetTaxRateFor(changeState).TaxPercent;
                    isStateTrue = true;
                }
                else if (changeState == "")
                {
                    changeState = oldOrder.State;
                    txRate = t.GetTaxRateFor(changeState).TaxPercent;
                    isStateTrue = true;
                }
                else Console.WriteLine("Invalid Input");
            } while (!isStateTrue);
            do
            {
                Console.Write("Current product type: {0}       ", oldOrder.ProductType);
                changeProductType = Console.ReadLine();
                var orProTrue = p.IsAllowedProduct(changeProductType);
                if (orProTrue)
                {
                    changeProductType = p.GetProductFor(changeProductType).ProductType;
                    isProductTrue = true;
                }
                else if (changeProductType == "")
                {
                    changeProductType = oldOrder.ProductType;
                    isProductTrue = true;
                }
                else Console.WriteLine("Invalid Input");
            } while (!isProductTrue);
            Console.WriteLine("");
            Console.Write("Current area: {0} Sqft       ", oldOrder.Area);
            var areaInput = Console.ReadLine();
            if (areaInput == "")
            {
                changeArea = oldOrder.Area;
            }
            else if (areaInput != "")
            {
                changeArea = decimal.Parse(areaInput);
            }
            else
                Console.WriteLine("Invalid Input");
            changeCostPerSquareFoot = p.GetProductFor(changeProductType).CostPerSquareFoot;
            changeLaborCostPerSquareFoot = p.GetProductFor(changeProductType).LaborCostPerSquareFoot;
            changeMaterialCost = c.MaterialTotalCalc(changeArea, changeCostPerSquareFoot);
            changeLaborCost = c.LaborTotalCalc(changeArea, changeLaborCostPerSquareFoot);
            subTotal = changeLaborCost + changeMaterialCost;
            changeTaxTotal = c.TaxTotalCalc(txRate, subTotal);
            changeTotal = c.TotalOrderCalc(subTotal, changeTaxTotal);

            oldOrder.OrderNumber = changeOrderNumber;
            oldOrder.CustomerName = changeCustomerName;
            oldOrder.State = changeState;
            oldOrder.TaxRate = txRate;
            oldOrder.ProductType = changeProductType;
            oldOrder.Area = changeArea;
            oldOrder.CostPerSquareFoot = changeCostPerSquareFoot;
            oldOrder.LaborCostPerSquareFoot = changeLaborCostPerSquareFoot;
            oldOrder.MaterialCost = changeMaterialCost;
            oldOrder.LaborCost = changeLaborCost;
            oldOrder.Tax = changeTaxTotal;
            oldOrder.Total = changeTotal;


            o.SaveFromMem(orderData, path);
            Console.WriteLine();
            Console.WriteLine();
            _orders.ShowNewOrder(listToEdit);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        private void DisplayOrders()
        {
            Console.Clear();
            
            var path = GetOrderPath();
            if (path == null)
                return;
            Console.Clear();
            bool isStateValid = false;
            List<Orders> searchForOrders = null;
            try
            {
                searchForOrders = o.LoadInMem(path);
            }
            catch
            {
              return;
            }

            do
            {
                Console.Write("Choose a state to display orders from      ");
                var state = Console.ReadLine().ToUpper();
                var isAllowedState = o.IsAllowedState(path, state);
                if (isAllowedState)
                {
                    var matches = searchForOrders.FirstOrDefault(or => or.State == state);
                    if (state == matches.State)
                    {

                        _orders.ShowNewOrder(searchForOrders.Where(x => x.State == matches.State).ToList());
                        isStateValid = true;
                    }
                    else
                        Console.WriteLine("Invalid Input. Press enter to continue");
                }
                else
                    Console.WriteLine("State does not exist in file. Press enter to continue");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
            } while (!isStateValid);
        }

        private string GetUserInput()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Display Orders");
            Console.WriteLine("2. Add an Order");
            Console.WriteLine("3. Edit an Order");
            Console.WriteLine("4. Remove an Order");
            Console.WriteLine("5. Quit");
            Console.WriteLine("");
            Console.WriteLine("Choose an order option");
            Console.WriteLine("=================================");
            //Console.WriteLine("Press M to change modes.");
            
            string selectedOption = Console.ReadLine();
            return selectedOption.ToUpper();
        }
    }
}
