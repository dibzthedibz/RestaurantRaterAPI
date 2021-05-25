using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double Rating { get; set; }
        public bool IsRecommended => Rating > 3.5;  //this is the same as doing the full "get" beneath with a bool to return the value if true. => means get based on "this" condition.
    }
}
