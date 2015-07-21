using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SWC_LMS.Models
{
    public class LmsUserViewRegistration : RegisterViewModel
    {
        

        public int UserId { get; set; }
        public string GuidId {get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string SuggestedRole { get; set; }
        public int? GradeLevelId { get; set; }
        public IEnumerable<SelectListItem> GradeLevelList { get; set; }

        public bool AdminRole { get; set; }
        public bool TeacherRole { get; set; }
        public bool StudentRole { get; set; }
        public bool ParentRole { get; set; }
       
    }
}