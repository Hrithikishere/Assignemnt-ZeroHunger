using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Requests()
        {
            var db = new ZeroHungerEntities1();
            var data = db.Employees.Find(Session["UserId"]);
            return View(data);
        }

        [HttpGet]
        public ActionResult RequestsDetails(int Id)
        {
            var db = new ZeroHungerEntities1();
            var data = db.Requests.Find(Id);

            return View(data);
        }

        [HttpPost]
        public ActionResult RequestsDetails(Request request)
        {
            var db = new ZeroHungerEntities1();
            var data = db.Requests.Find(request.Id);
            data.Status = request.Status;
            db.SaveChanges();
            return RedirectToAction("Requests");
        }

        public ActionResult Profile()
        {
            var db = new ZeroHungerEntities1();
            var data = db.Employees.Find(Session["UserId"]);
            return View(data);
        }
    }
}