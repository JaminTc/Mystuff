using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWC_LMS.Models.Api
{
    public class StudentSearch
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public byte Gradelevel { get; set; }
        public string UserId { get; set; }
    }
}