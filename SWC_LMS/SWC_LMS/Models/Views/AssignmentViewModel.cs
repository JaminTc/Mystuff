using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWC_LMS.Models.Views
{
    public class AssignmentViewModel
    {
        public  AssignmentViewModel()
        {
            this.RosterAssignments = new HashSet<RosterAssignment>();
        }
    
        public int AssignmentId { get; set; }
        public int CourseId { get; set; }
        public string AssignmentName { get; set; }
        public int PossiblePoints { get; set; }
        public string DueDate { get; set; }
        public string AssignmentDescription { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual ICollection<RosterAssignment> RosterAssignments { get; set; }
    }
}