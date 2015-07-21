using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWC_LMS.Models.Api
{
    public class RosterSearch
    {
        public string LastName { get; set; }
        public byte?  GradeLevelId { get; set; }

        
    }
}