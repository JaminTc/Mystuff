using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWC_LMS.Models.Api
{
    public class GradeIds
    {
        public string Percent { get; set; }
        public decimal PointsEarned { get; set; }
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
    }
}