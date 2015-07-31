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

        public ActionResult Suggestions()
        {
            VotesController vote= new VotesController();
            var snack = vote.Get();
            var snacks = new ExistingSnackList();
            foreach (var m in snack)
            {
                if (m.optional != "false")
                {
                    snacks.SelectSnackName = snack.Select(x => new System.Web.Mvc.SelectListItem()
                    {
                        Value = x.id.ToString(),
                        Text = x.name.ToString()
                    });
                }
            }
            return View(snacks);
        }

        public ActionResult AddSuggestions(ExistingSnackList snacks)
        {
            ExistingSnacks snack = new ExistingSnacks();
            snack.id = snacks.Id;
            snack.name = snacks.Name;
            snack.optional = "true";
            snack.purchaseLocations = snacks.PurchaseLocations;
            _repo.Post(snack);
           return RedirectToAction("Votes");
        }

        public ActionResult ShoppingList()
        {
            return View(); 
        }
    }
}