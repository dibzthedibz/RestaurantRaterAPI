using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RestaurantController : ApiController
    {

        private RestaurantDbContext _context = new RestaurantDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (model == null)
            {
                return BadRequest("Oops, you messed up. Your request body CANNOT be empty");
            }

            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }

        //GetAllRestaurants
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> rList = await _context.Restaurants.ToListAsync();
            return Ok(rList);
        }
        //[HttpGet]
        ////GetById

        //[HttpPut]
        ////Update(Put)

        //[HttpDelete]
        ////Delete
    }
}
