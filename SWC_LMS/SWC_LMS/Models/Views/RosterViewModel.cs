using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWC_LMS.Models.Views
{
    public class RosterViewModel
    {
        public string CourseName { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? GradeLevel { get; set; }
        public int CourseId { set; get; }

    }
}