using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        // GET: Authentication
        public ActionResult Login(string Email, string Password)
        {
            var db = new ZeroHungerEntities1();


            var checkAdmin = (from admin in db.Admins
                        where admin.Email == Email
                        select admin).SingleOrDefault();

            if (checkAdmin != null) { 

                if(checkAdmin.Password == Password)
                {
                    Session["UserId"]= checkAdmin.Id;
                    return RedirectToAction("Employees", "Admin");
                }
            }
            

            var checkEmployee = (from employee in db.Employees
                        where employee.Email == Email
                        select employee).SingleOrDefault();

            if (checkEmployee != null) { 

                if(checkEmployee.Password == Password)
                {
                    Session["UserId"]= checkEmployee.Id;
                    return RedirectToAction("Requests", "Employee");
                }
            }
             

            var checkRestaurant = (from resto in db.Restaurants
                        where resto.Email == Email
                        select resto).SingleOrDefault();

            if (checkRestaurant != null) { 

                if(checkRestaurant.Password == Password)
                {
                    Session["UserId"]= checkRestaurant.Id;
                    return RedirectToAction("Requests", "Restaurant");
                }
            }



            /*if (employee != null)
            {

                if (employee.Password == Password)
                {
                    Session["UserId"] = employee.Id;

                    return RedirectToAction("Requests", "Employee");
                }
            }

            if (restarurant != null)
            {

                if (restarurant.Password == Password)
                {
                    Session["UserId"] = restarurant.Id;

                    return RedirectToAction("AddRequest", "Restaurant");
                }
            }*/

            return View();
        }


    }
}