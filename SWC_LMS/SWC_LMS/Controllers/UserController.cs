using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using System.Web.WebSockets;
using SWC_LMS.BusinessLogic;
using SWC_LMS.Models;

namespace SWC_LMS.Controllers
{
    public class UserController : Controller
    {
        private UserOperations _opp = new UserOperations();
        // GET: User
        public ActionResult Index()
        {
            return View(_opp.GetAll());
        }

        public ActionResult LogIn()
        {
            List<GradeLevel> grade = _opp.GetAllGrades();

            var gradeList = new LmsUserViewRegistration
            {
                GradeLevelList = grade.Select(x => new System.Web.Mvc.SelectListItem()
                {
                    Value = x.GradeLevelId.ToString(),
                    Text = x.GradeLevelName.ToString()
                })
            };

            return View(gradeList);
        }
    
        public ActionResult GetAllUsers()
        {
            _opp.GetAll();
            return View();
        }

        public ActionResult GetThisUserById(int id)
        {
            _opp.GetById(id);
            return View();
        }


        public ActionResult _GradeLevelPartial()
        {
            var grade = _opp.GetAllGrades();
            ViewBag.GradeNameList = grade;
            return PartialView();
        }


    }
}