using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Service;
using Project.DAL;

namespace Project2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home ---- All vehicle manufacturer
        public ActionResult Index()
        {
            MakeVehicle makeVehicle = new MakeVehicle();
            List<VehicleMake> vehicleMaker = makeVehicle.GetAllMaker();
            return View(vehicleMaker);
        }
        // Call form to enter manufacturers, get data
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        // Upload the resulting data into the database from the get data view
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            VehicleMake vehicleMake = new VehicleMake();
            vehicleMake.VehicleName = formCollection["VehicleName"];
            vehicleMake.VehicleAbbreviation = formCollection["VehicleAbbreviation"];

            MakeVehicle makeVehicle = new MakeVehicle();
            makeVehicle.AddVehicleMake(vehicleMake);
            return RedirectToAction("Index");
        }
    }
}