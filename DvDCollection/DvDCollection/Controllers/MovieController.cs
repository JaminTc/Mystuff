using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DvDCollection.BizLogic;

namespace DvDCollection.Controllers
{
    public class MovieController : Controller
    {
        BusinessLogic _bll = new BusinessLogic();
        // GET: Movie
        public ActionResult Index()
        {
            return View(_bll.GetAllMovies());
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Display()
        {
            return View();
        }
    }
}