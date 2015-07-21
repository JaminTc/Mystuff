using CarDealership.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    public class CarController : Controller
    {
        ICarRepository _repo = new DBCarRepository();

        // GET: Car
        public ActionResult Index()
        {
            var cars = _repo.GetAllCars();
            return View(cars);
        }

        public ActionResult Details(int id)
        {
            var car = _repo.GetCarById(id);
            return View(car);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCar(Car newCar)
        {
            ViewBag.Message = "Add a new Car!";
            if (ModelState.IsValid)
            {
                DBCarRepository car = new DBCarRepository();
                car.AddCar(newCar);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Add");
            }
          
        }

        public ActionResult Edit(int id)
        {
            var car = _repo.GetCarById(id);
            return View(car);
        }
        [HttpPost]
        public ActionResult EditCar(Car editCar)
        {
            ViewBag.Message = "Edit your car!";
            if (ModelState.IsValid)
            {
                DBCarRepository car = new DBCarRepository();
                car.EditCar(editCar);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
        }

        public ActionResult Delete(int id)
        {
            var car = _repo.GetCarById(id);
            return View(car);
        }
        public ActionResult DeleteCar(int id)
        {
            DBCarRepository car = new DBCarRepository();
            car.DeleteCar(id);

            var cars = car.GetAllCars();
            return View("Index", cars);
        }

        public ActionResult CarRoute(string Year, string Make, string Model)
        {
            var cars = _repo.GetAllCars();
            var results = from id in cars
                where id.Make == Make && id.Model == Model && id.Year == Year
                select id;
            if (results.Count() == 1)
                {
                var choice = results.First();
                var car = _repo.GetCarById(choice.Id);
                return View("Details", car);
                }
            return View("");
        }
    }
}