using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWC_LMS.Models.Views
{
    public class GradeBookViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public int UserId { get; set; }
        public List<RosterAssignment> Assignments { get; set; }
        
    }
}