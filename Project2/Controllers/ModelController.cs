using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Service;
using Project.DAL;

namespace Project2.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        public ActionResult Models()
        {
            ModelVehicle modelVehicle = new ModelVehicle();
            List<VehicleModel> vehicleModels = modelVehicle.GetAllModels();
            return View(vehicleModels);
        }
    }
}