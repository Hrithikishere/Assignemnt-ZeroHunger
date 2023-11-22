using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models.DTOs
{
    public class TemporaryRequestDTO
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string FoodName { get; set; }
        public int FoodQuantity { get; set; }
        public System.DateTime MaxPreserveTime { get; set; }
        public string Status { get; set; }
    }
}