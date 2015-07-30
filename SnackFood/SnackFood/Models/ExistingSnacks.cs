using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnackFood.Models
{
    public class ExistingSnacks
    {
        public string id { get; set; }
        public string name { get; set; }
        public string optional { get; set; }
        public string purchaseLocations { get; set; }
        public string purchaseCount { get; set; }
        public string lastPurchaseDate { get; set; }
    }
}