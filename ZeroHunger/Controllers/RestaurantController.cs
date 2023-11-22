using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.Models.DTOs;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        [HttpGet]
        public ActionResult AddRequest(){
        
            return View();
        }

        public RequestDTO Convert(Request request)
        {
            var converted = new RequestDTO()
            {
                FoodName = request.FoodName,
                FoodQuantity = request.FoodQuantity,
                MaxPreserveTime = request.MaxPreserveTime,
                RestaurantId = request.RestaurantId,
                Status = request.Status,
            };

            return converted;
        }

        public Request Convert(RequestDTO requestDTO)
        {
            var converted = new Request()
            {
                FoodName = requestDTO.FoodName,
                FoodQuantity = requestDTO.FoodQuantity,
                MaxPreserveTime = requestDTO.MaxPreserveTime,
                RestaurantId = requestDTO.RestaurantId,
                Status = requestDTO.Status,
            };

            return converted;
        }

        [HttpPost]
        public ActionResult AddRequest(TemporaryRequest request){

            if (ModelState.IsValid)
            {
                //Request request = Convert(requestdto);
                var db = new ZeroHungerEntities1();
                var data = db.TemporaryRequests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Requests");
            }
            return View();
        }

        public ActionResult Requests()
        {
            var db = new ZeroHungerEntities1();
            var data = db.Restaurants.Find(Session["UserId"]);
            return View(data);
        }

        public ActionResult Profile()
        {
            var db = new ZeroHungerEntities1();
            var data = db.Restaurants.Find(Session["UserId"]);
            return View(data);
        }
    }
}