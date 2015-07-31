using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnackFood.Models
{
    public class ExistingSnackList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Optional { get; set; }
        public string PurchaseLocations { get; set; }
        public string PurchaseCount { get; set; }
        public string LastPurchaseDate { get; set; }
        public IEnumerable<SelectListItem> SelectSnackName { get; set; }
    }
}