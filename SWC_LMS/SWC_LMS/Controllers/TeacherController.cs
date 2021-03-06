﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWC_LMS.BusinessLogic;
using SWC_LMS.Models.Views;

namespace SWC_LMS.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private TeacherOperations _opp1 = new TeacherOperations();
        private UserOperations _opp2 = new UserOperations();

        public ActionResult TeacherDashboard(int id)
        {
            var courses = _opp1.GetTeachersCourseInfo(id);
            ViewBag.teacherId = id;
            ViewBag.teacherString = "Teacher";
            return View(courses);
        }

        
        public ActionResult GetThisCourse(int id)
        {
            ViewBag.courseId = id;

            var thisCourse = _opp1.GetThisCourse(id);
            byte gradeLevel = Convert.ToByte(thisCourse.GradeLevel);
            var startDate = thisCourse.StartDate.ToShortDateString();
            var endDate = thisCourse.EndDate.ToShortDateString();
            List<GradeLevel> gradeList = _opp2.GetAllGrades();
            List<Subject> subjects = _opp1.GetAllSubjects();
            var course = new TeacherViewModel()
            {
                GradeLevelList = gradeList.Select(x => new System.Web.Mvc.SelectListItem()
                {
                    Value = x.GradeLevelId.ToString(),
                    Text = x.GradeLevelName.ToString()
                }),
                SubjectList = subjects.Select(x => new System.Web.Mvc.SelectListItem()
                {
                    Value = x.SubjectId.ToString(),
                    Text = x.SubjectName.ToString()
                })
            };

            course.CourseId = thisCourse.CourseId;
            course.UserId = thisCourse.UserId;
            course.SubjectId = thisCourse.SubjectId;
            course.CourseName = thisCourse.CourseName;
            course.CourseDescription = thisCourse.CourseDescription;
            course.GradeLevel = gradeLevel;
            course.IsArchived = thisCourse.IsArchived;
            course.StartDate = startDate;
            course.EndDate = endDate;
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(TeacherViewModel course)
        {
            var id = course.UserId;
            _opp1.EditCourse(course);
            return RedirectToAction("TeacherDashboard", new{id});
        }

        public ActionResult AddCourse(int id)
        {
            List<GradeLevel> gradeList = _opp2.GetAllGrades();
            List<Subject> subjects = _opp1.GetAllSubjects();
            DateTime Date = new DateTime();
            var startDate = Date.ToShortDateString();
            var endDate = Date.ToShortDateString();
            var course = new TeacherViewModel()
            {
                GradeLevelList = gradeList.Select(x => new System.Web.Mvc.SelectListItem()
                {
                    Value = x.GradeLevelId.ToString(),
                    Text = x.GradeLevelName.ToString()
                }),
                SubjectList = subjects.Select(x => new System.Web.Mvc.SelectListItem()
                {
                    Value = x.SubjectId.ToString(),
                    Text = x.SubjectName.ToString()
                })
            };
            course.StartDate = startDate;
            course.EndDate = endDate;
            course.UserId = id;
            ViewBag.TeacherId = course.UserId;
            return View("AddCourse", course);   
        }

        [HttpPost]
        public ActionResult AddThisCourse(TeacherViewModel course)
        {
            var id = course.UserId;
            _opp1.AddNewCourse(course);
            return RedirectToAction("TeacherDashboard", new {id});
        }

        public ActionResult AddAssingment(int id)
        {
            ViewBag.courseId = id;

            var course = _opp1.GetThisCourse(id);
            var courseName = course.CourseName;
            var courseId = course.CourseId;
            var userId = course.UserId;
            var thisAssignment = new AssignmentViewModel();
            ViewBag.CourseName = courseName;
            ViewBag.UserId = userId;
            thisAssignment.CourseId = courseId;
            return View(thisAssignment);
        }

        [HttpPost]
        public ActionResult AddNewAssingment(AssignmentViewModel assignment)
        {
            _opp1.AddAssignment(assignment);
            var id = assignment.UserId;
            var user = _opp1.GetTeachersCourseInfo(id);

            return View("TeacherDashboard", user);
        }

        public ActionResult Roster(int id)
        {
            List<RosterViewModel> roster = _opp1.GetStudentsInCourse(id);
            ViewBag.courseId = id;
            return View(roster);
        }

        public ActionResult GradeBook(int id)
        {
            var course = _opp1.GetThisCourse(id);
            var courseId = course.CourseId;
            var courseName = course.CourseName;
            ViewBag.Course = courseId;
            ViewBag.CourseName = courseName;
            return View(_opp1.Gradebook(id));
        }
    }
}