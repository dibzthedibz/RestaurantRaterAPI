using RestaurantRaterAPI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RatingController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> PostRating(Rating model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Oops, you messed up. Your request body CANNOT be empty");
            }
            Restaurant restaurant = await _context.Restaurants.FindAsync(model.RestaurantId);

            if (restaurant == null)
            {
                return BadRequest($"Oops, {model.RestaurantId} Doesn't Seem to Exist.");
            }
            _context.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You Rated {restaurant.Name} successfully");
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetRatingsByRestaurantId(Rating model)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(model.RestaurantId);

            if (restaurant == null)
            {
                return BadRequest($"Oops, {model.RestaurantId} Doesn't Seem to Exist.");
            }

            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRating(int id, Rating updatedRating)
        {

            Rating rating = await _context.Ratings.FindAsync(id);

            if (rating != null)
            {
                rating.ID = updatedRating.ID;  //this is giving me a functional issue; have to have a 2 in the uri and in the key field. How to fix?
                rating.FoodScore = updatedRating.FoodScore;
                rating.EnvironmentScore = updatedRating.EnvironmentScore;
                rating.CleanlinessScore = updatedRating.CleanlinessScore;
                await _context.SaveChangesAsync();
                return Ok("Content Successfully Updated");
            }
            return NotFound();

        }
        [HttpDelete]

        public async Task<IHttpActionResult> DeleteRating(int id)
        {

            Rating rating = await _context.Ratings.FindAsync(id);

            if (rating == null)
            {
                return NotFound();
            }

            _context.Ratings.Remove(rating);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("Rating Successfully Deleted");
            }
            return InternalServerError();
        }
    }
}
