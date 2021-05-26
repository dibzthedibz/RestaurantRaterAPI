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

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public double Rating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (Rating rating in Ratings)
                {
                    totalAverageRating += rating.AverageRating;
                }
                return totalAverageRating / Ratings.Count;
            }
        }
        public bool IsRecommended => Rating > 8.5;  //this is the same as doing the full "get" beneath with a bool to return the value if true. => means get based on "this" condition.
    }
}
