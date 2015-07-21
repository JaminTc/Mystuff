using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWC_LMS.BusinessLogic;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Controllers
{
    public class ParentAndStudentController : Controller
    {
        PStudnetOperations _opp = new PStudnetOperations();

        [Authorize(Roles = "Parent")]
        public ActionResult ParentDashboard(int id)
        {
            List<ParentViewModel> listOfChildren = _opp.GetParentsChildren(18);  

            return View(listOfChildren);
        }

        [Authorize(Roles = "Student,Parent")]
        public ActionResult StudentDashboard(int id)
        {
            List<GetCoursesForStudent_Result> listOfCourses = _opp.GetCoursesForStudent(id);
            return View(listOfCourses);
        }

        [Authorize(Roles = "Student")]
        public ActionResult Grades(GetCoursesForStudent_Result ids)
        {
            List<GetAssignmentGrades_Result> assignments = _opp.GetAssignmentGrades(ids.RosterId);

            ViewBag.CourseName = ids.CourseName;
            return View(assignments);
        }
    }
}