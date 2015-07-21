using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWC_LMS.BusinessLogic;
using SWC_LMS.Models;

namespace SWC_LMS.Controllers
{
    [Authorize (Roles="Admin")]
    public class AdminController : Controller
    {
        UserOperations _opp1 = new UserOperations();
        AdminOperations _opp2 = new AdminOperations();
        
        public ActionResult AdminDashboard()
        {
            List<LmsUser> userList = _opp1.GetAll();
            return View(userList);
        }

        public ActionResult AdminSearch()
        {
            List<LmsUser> userList = _opp1.GetAll();
            return View(userList);
        }

        public ActionResult Edit(int id)
        {
            LmsUser edit = _opp1.GetById(id);
            List<GradeLevel> gradeList = _opp1.GetAllGrades();
            var grades = new LmsUserViewRegistration
            {
                GradeLevelList = gradeList.Select(x => new SelectListItem()
                {
                    Value = x.GradeLevelId.ToString(),
                    Text = x.GradeLevelName.ToString()
                })
            };
            grades.UserId = id;
            grades.Email = edit.Email;
            grades.FirstName = edit.FirstName;
            grades.LastName = edit.LastName;
            grades.SuggestedRole = edit.SuggestedRole;
            grades.GradeLevelId = edit.GradeLevelId;
            grades.GuidId = edit.Id;
            return View(grades);
        }

        [HttpPost]
        public ActionResult EditUser(LmsUserViewRegistration user)
        { 
            if (user.GuidId == null)
            {
                var guid = _opp2.GetGuidByEmail(user.Email);
                user.GuidId = guid;
            }

            _opp2.Edit(user);

            if (user.AdminRole)
                _opp2.AssignRole(user.GuidId, "1");
            if (!user.AdminRole)
                _opp2.RemoveRole(user.GuidId, "1");

            if (user.TeacherRole)
                _opp2.AssignRole(user.GuidId, "2");
            if (!user.TeacherRole)
                _opp2.RemoveRole(user.GuidId, "2");

            if (user.StudentRole)
                _opp2.AssignRole(user.GuidId, "3");
            if (!user.StudentRole)
                _opp2.RemoveRole(user.GuidId, "3");

            if (user.ParentRole)
                _opp2.AssignRole(user.GuidId, "4");
            if (!user.ParentRole)
                _opp2.RemoveRole(user.GuidId, "4");

            return RedirectToAction("AdminDashboard", "Admin");
        }
    }
}