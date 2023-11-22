using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models.DTOs
{
    public class RequestDTO
    {
        [Required]
        public int RestaurantId { get; set; }
        [Required]

        public string FoodName { get; set; }
        [Required]

        public int FoodQuantity { get; set; }
        [Required]

        public System.DateTime MaxPreserveTime { get; set; }
        [Required]

        public string Status { get; set; }
    }
}