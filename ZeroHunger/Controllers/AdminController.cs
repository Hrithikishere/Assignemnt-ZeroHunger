using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.Models.DTOs;

namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Profile()
        {
            var db = new ZeroHungerEntities1();
            var data = db.Admins.Find(Session["UserId"]);
            return View(data);
        }


        //---------------------------------------------

        public EmployeeDTO Convert(Employee employee)
        {
            var converted = new EmployeeDTO()
            {
                Name = employee.Name,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Password = employee.Password,
                Phone = employee.Phone,
            };

            return converted;
        }

        public Employee Convert(EmployeeDTO employee)
        {
            var converted = new Employee()
            {
                Name = employee.Name,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Password = employee.Password,
                Phone = employee.Phone,
            };

            return converted;
        }

        // GET: Admin
        public ActionResult Employees()
        {


            var db = new ZeroHungerEntities1();
            var data = db.Employees.ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<EmployeeDTO>>(data);
            return View(converted);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeDTO employeedto)
        {
            if (ModelState.IsValid)
            {
                Employee employee = Convert(employeedto);
                var db = new ZeroHungerEntities1();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Employees");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditEmployee(int Id)
        {
            var db = new ZeroHungerEntities1();
            var data = db.Employees.Find(Id);
            return View(data);
        }
        
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            var db = new ZeroHungerEntities1();
            var data = db.Employees.Find(employee.Id);
            data.Name = employee.Name;
            data.Email = employee.Email;
            data.Phone = employee.Phone;
            data.Password = employee.Password;
            data.DateOfBirth = employee.DateOfBirth;
            db.SaveChanges();
            return RedirectToAction("Employees");
        }

        public ActionResult DeleteEmployee(int Id)
        {
            var db = new ZeroHungerEntities1();
            var data = db.Employees.Find(Id);
            db.Employees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Employees");
        }



        //--------------------------RESTO-------------------------------


        public RestaurantDTO Convert(Restaurant restaurant)
        {
            var converted = new RestaurantDTO()
            {
                Name = restaurant.Name,
                Email = restaurant.Email,
                Address = restaurant.Address,
                Password = restaurant.Password,
                Phone = restaurant.Phone,
            };

            return converted;
        }

        public Restaurant Convert(RestaurantDTO restaurant)
        {
            var converted = new Restaurant()
            {
                Name = restaurant.Name,
                Email = restaurant.Email,
                Address = restaurant.Address,
                Password = restaurant.Password,
                Phone = restaurant.Phone,
            };

            return converted;
        }

        // GET: Admin
        public ActionResult Restaurants()
        {
            var db = new ZeroHungerEntities1();
            var data = db.Restaurants.ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Restaurant, RestaurantDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<RestaurantDTO>>(data);
            return View(converted);
        }

        [HttpGet]
        public ActionResult AddRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerEntities1();
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Restaurants");
            }
            return View();

        }

        [HttpGet]
        public ActionResult EditRestaurant(int Id)
        {
            var db = new ZeroHungerEntities1();
            var data = db.Restaurants.Find(Id);
            return View(data);
        }
        
        [HttpPost]
        public ActionResult EditRestaurant(Restaurant restaurant)
        {
            var db = new ZeroHungerEntities1();
            var data = db.Restaurants.Find(restaurant.Id);
            data.Name = restaurant.Name;
            data.Email = restaurant.Email;
            data.Phone = restaurant.Phone;
            data.Password = restaurant.Password;
            data.Address = restaurant.Address;
            db.SaveChanges();
            return RedirectToAction("Restaurants");
        }

        public ActionResult DeleteRestaurant(int Id)
        {
            var db = new ZeroHungerEntities1();
            var data = db.Restaurants.Find(Id);
            db.Restaurants.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Restaurants");
        }



        //--------------------------REQ-----------------------------------

        public ActionResult Requests()
        {
            var db = new ZeroHungerEntities1();
            var data = db.TemporaryRequests.ToList();



            return View(data);
        }

        public ActionResult AcceptedRequests()
        {
            var db = new ZeroHungerEntities1();
            var data = db.Requests.ToList();

            return View(data);
        }

        [HttpGet]
        public ActionResult RequestsDetails(int Id)
        {
            var db = new ZeroHungerEntities1();
            var data = db.TemporaryRequests.Find(Id);
            ViewBag.Employees = db.Employees.ToList();

            return View(data);
        }

        [HttpPost]
        public ActionResult RequestsDetails(Request request)
        {
            request.Status = "Accepted";
            var db = new ZeroHungerEntities1();
            db.Requests.Add(request);

            var temp = db.TemporaryRequests.Find(request.Id);
            db.TemporaryRequests.Remove(temp);


            db.SaveChanges();
            return RedirectToAction("AcceptedRequests");
        }

        public ActionResult RejectRequest(int Id)
        {
            var db = new ZeroHungerEntities1();
            var temp = db.TemporaryRequests.Find(Id);
            db.TemporaryRequests.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Requests");
        }
    }
}

/*
 * <select>
                    <option selected>Select an Employee</option>
                    @foreach (var ename in ViewBag.Employees)
                    {
                        <option value="@ename.Id">@ename.Name</option>
                    }
                </select>
*/