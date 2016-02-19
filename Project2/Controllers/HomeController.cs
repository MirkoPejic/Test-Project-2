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
        // GET: Home
        public ActionResult Index()
        {
            Maker maker = new Maker();
            List<VehicleMake> vehicleMaker = maker.VehicleMaker.ToList();
            return View(vehicleMaker);
        }
    }
}