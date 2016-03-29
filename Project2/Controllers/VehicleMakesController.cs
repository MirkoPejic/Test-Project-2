using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.DAL;
using Project.Service;
using PagedList;

namespace Project2.Controllers
{
    public class VehicleMakesController : Controller
    {
        private VehiclesDBEntities db = new VehiclesDBEntities();

        // GET: VehicleMakes
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbbreviationSortParm = sortOrder == "abbreviation" ? "abbreviation_desc" : "abbreviation";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var vehicleMakes = from vMakers in db.VehicleMakes
                               select vMakers;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicleMakes = vehicleMakes.Where(v => v.VehicleName.Contains(searchString)
                                       || v.VehicleAbbreviation.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.VehicleName);
                    break;
                case "abbreviation":
                    vehicleMakes = vehicleMakes.OrderBy(v => v.VehicleAbbreviation);
                    break;
                case "abbreviation_desc":
                    vehicleMakes = vehicleMakes.OrderByDescending(v => v.VehicleAbbreviation);
                    break;
                default:
                    vehicleMakes = vehicleMakes.OrderBy(v => v.VehicleName);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(vehicleMakes.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleMakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleName,VehicleAbbreviation")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                db.VehicleMakes.Add(vehicleMake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleName,VehicleAbbreviation")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleMake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
