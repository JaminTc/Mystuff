using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Interfaces
{
    public interface IOrdersRepository
    {
        
        List<Orders> GetOrders(string path);
        void SaveOrder(List<Orders> order, string path);
    }
}
