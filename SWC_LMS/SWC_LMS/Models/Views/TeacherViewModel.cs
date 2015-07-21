using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWC_LMS.Models.Views
{
    public class TeacherViewModel
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public byte GradeLevel { get; set; }
        public bool IsArchived { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public IEnumerable<SelectListItem> GradeLevelList { get; set; }
        public IEnumerable<SelectListItem> SubjectList { get; set; }
    }
}