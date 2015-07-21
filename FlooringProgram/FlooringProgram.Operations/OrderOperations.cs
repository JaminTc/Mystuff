using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Data.Orders;

namespace FlooringProgram.Operations
{
    public class OrderOperations
    {
        public List<Orders> LoadInMem(string path)
        {
            IOrdersRepository repository = OrderRepositoryFactory.GetOrdersRepository();
            var AllOrders = repository.GetOrders(path);

            return AllOrders;

        }

        public void SaveFromMem(List<Orders> savedOrderData, string path)
        {
            IOrdersRepository repository = OrderRepositoryFactory.GetOrdersRepository();
            repository.SaveOrder(savedOrderData,path);
        }
        public bool IsAllowedState(string path ,string state)
        {
            IOrdersRepository repository = OrderRepositoryFactory.GetOrdersRepository();
            var allStates = repository.GetOrders(path);

            return allStates.Any(t => t.State == state);
        }
    }
}
