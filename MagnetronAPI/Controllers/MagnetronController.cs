using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagnetronAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MagnetronAPI.Controllers
{
    public class MagnetronController : Controller
    {
        private readonly MagnetonContext _db;
        public MagnetronController(MagnetonContext magnetonContext)
        {
            _db = magnetonContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Dish>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAllDishes")]
        public IActionResult GetAllDishes()
        {
            List<Dish> dishes = _db.Dishes.Include(dish => dish.Preps).ToList();
            return Ok(dishes);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dish))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetDish")]
        public IActionResult GetDish(int id)
        {
            Dish dish = _db.Dishes.Where(d => d.DishId == id).Include(dish => dish.Preps).FirstOrDefault();
            return Ok(dish);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("AddDish")]
        public IActionResult AddDish(string name)
        {
            Dish dish = new() { 
                Name = name 
            };
            _db.Dishes.Add(dish);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("AddPrep")]
        public IActionResult AddPrep(int dishID, string mode, int watt, int temp, int rating, string notes)
        {
            Prep prep = new()
            {
                Mode = mode,
                Watt = watt,
                Temp = temp,
                Rating = rating,
                Notes = notes
            };

            var dish = _db.Dishes.Find(dishID);
            if (dish != null) 
            {
                dish.Preps ??= new();
                dish.Preps.Add(prep);
            }
            else
            {
                return BadRequest("id does not exist");
            }

            _db.SaveChanges();

            return Ok();
        }
    }
}
