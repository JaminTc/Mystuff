using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Operations
{
     public class TotalCostOperations
    {
        public decimal MaterialTotalCalc(decimal area, decimal cost)
        {
            return area * cost;
        }

        public decimal LaborTotalCalc(decimal area, decimal cost)
        {
            return area * cost;
        }

        public decimal TaxTotalCalc(decimal stateTax, decimal subTotal)
        {
            return ((stateTax / 100) * subTotal);
        }

        public decimal TotalOrderCalc(decimal subtotal, decimal taxTotal)
        {
            return subtotal + taxTotal;
        }
    }
}
