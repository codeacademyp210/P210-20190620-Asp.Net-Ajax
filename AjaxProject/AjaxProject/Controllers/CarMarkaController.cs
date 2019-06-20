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
    public class CarMarkaController : Controller
    {
        private CarContext db = new CarContext();

        // GET: CarMarka
        public ActionResult Index()
        {
            return View(db.CarMarkas.ToList());
        }

        // GET: CarMarka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMarka carMarka = db.CarMarkas.Find(id);
            if (carMarka == null)
            {
                return HttpNotFound();
            }
            return View(carMarka);
        }

        // GET: CarMarka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarMarka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] CarMarka carMarka)
        {
            if (ModelState.IsValid)
            {
                db.CarMarkas.Add(carMarka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carMarka);
        }

        // GET: CarMarka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMarka carMarka = db.CarMarkas.Find(id);
            if (carMarka == null)
            {
                return HttpNotFound();
            }
            return View(carMarka);
        }

        // POST: CarMarka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CarMarka carMarka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carMarka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carMarka);
        }

        // GET: CarMarka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarMarka carMarka = db.CarMarkas.Find(id);
            if (carMarka == null)
            {
                return HttpNotFound();
            }
            return View(carMarka);
        }

        // POST: CarMarka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarMarka carMarka = db.CarMarkas.Find(id);
            db.CarMarkas.Remove(carMarka);
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
