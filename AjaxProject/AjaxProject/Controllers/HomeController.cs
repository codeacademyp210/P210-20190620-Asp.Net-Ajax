using AjaxProject.DAL;
using AjaxProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AjaxProject.Controllers
{
    public class HomeController : Controller
    {
        private CarContext db = new CarContext();

        public ActionResult Index()
        {
            List<CarMarka> markas = db.CarMarkas.ToList();
            return View(markas);
        }

      
        public ActionResult GetModels(int id)
        {
            return Json(db.CarModels.Where(m => m.CarMarkaID == id).Select(m => new { m.Id, m.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateMarka(CarMarka marka)
        {
            Thread.Sleep(1000);
            object output = new {
                status = 0,
                message = "Error occured"
            };

            if (marka != null)
            {
                if (!string.IsNullOrEmpty(marka.Name))
                {
                    db.CarMarkas.Add(marka);
                    db.SaveChanges();
                    output = new
                    {
                        status = 1,
                        message = "Marka created",
                        marka
                    };

                }
            }
            return Json(output, JsonRequestBehavior.AllowGet);
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