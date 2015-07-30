using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnackFood.Controllers.api;
using SnackFood.Models;
using SnackFood.Repositories;

namespace SnackFood.Controllers
{
    public class HomeController : Controller
    {
        VotesRepo _repo = new VotesRepo();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Votes()
        {
            return View();
        }

        public ActionResult Suggestions(ExistingSnacks snacks)
        {
            VotesController vote= new VotesController();
            var snack = vote.Get();
            IEnumerable<SelectListItem> selectSnackName;
            foreach (var m in snack)
            {
                if (m.optional != "false")
                {
                    
                }
            }
            return View();
        }

        public ActionResult AddSuggestions(ExistingSnacks snacks)
        {
            _repo.Post(snacks);
           return RedirectToAction("Votes");
        }
    }
}