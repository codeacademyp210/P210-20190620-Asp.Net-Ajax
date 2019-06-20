using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AjaxProject.DAL;
using AjaxProject.Models;

namespace AjaxProject.Controllers
{
    public class CarModelController : Controller
    {
        private CarContext db = new CarContext();

        // GET: CarModel
        public ActionResult Index()
        {
            var carModels = db.CarModels.Include(c => c.CarMarka);
            return View(carModels.ToList());
        }

        // GET: CarModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // GET: CarModel/Create
        public ActionResult Create()
        {
            ViewBag.CarMarkaID = new SelectList(db.CarMarkas, "Id", "Name");
            return View();
        }

        // POST: CarModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CarMarkaID")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.CarModels.Add(carModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarMarkaID = new SelectList(db.CarMarkas, "Id", "Name", carModel.CarMarkaID);
            return View(carModel);
        }

        // GET: CarModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarMarkaID = new SelectList(db.CarMarkas, "Id", "Name", carModel.CarMarkaID);
            return View(carModel);
        }

        // POST: CarModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CarMarkaID")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarMarkaID = new SelectList(db.CarMarkas, "Id", "Name", carModel.CarMarkaID);
            return View(carModel);
        }

        // GET: CarModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = db.CarModels.Find(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: CarModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarModel carModel = db.CarModels.Find(id);
            db.CarModels.Remove(carModel);
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
