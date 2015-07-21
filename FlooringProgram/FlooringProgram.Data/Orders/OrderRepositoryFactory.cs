using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.Orders
{
    public class OrderRepositoryFactory
    {
        public static IOrdersRepository GetOrdersRepository()
        {
            switch (ConfigurationSettings.GetMode())
            {
                case "Prod":
                    return new OrderFileRepository();
                case "Test":
                    return new OrderTestRepository();
            }

            return null;
        }
    }
}
