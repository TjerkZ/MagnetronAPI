using DAL;
using DAL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace MagnetronAPI.Controllers
{
    public class MagnetronController : Controller
    {
        private readonly MagnetronDAO _magnetronDAO;
        public MagnetronController(MagnetronDAO magnetronDAO)
        {
            _magnetronDAO = magnetronDAO;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Dish>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAllDishes")]
        public async Task<IActionResult> GetAllDishes()
        {
            List<Dish> dishes = await _magnetronDAO.GetAllDishesAsync();
            return Ok(dishes);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dish))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetDish")]
        public async Task<IActionResult> GetDish(string id)
        {
            //Dish dish = _db.Dishes.Where(d => d.DishId == id).Include(dish => dish.Preps).FirstOrDefault();
            Dish dish = await _magnetronDAO.GetDishAsync(id);
            return Ok(dish);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MagnetronBrand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAllMagnetrons")]
        public async Task<IActionResult> GetAllMagnetrons()
        {
            List<MagnetronBrand> magnetrons = await _magnetronDAO.GetAllMagnetronsAsync();
            return Ok(magnetrons);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("AddDish")]
        public async Task<IActionResult> AddDish(string name, string brand)
        {
            Dish dish = new()
            {
                Name = name,
                Brand = brand
            };

            await _magnetronDAO.AddDishAsync(dish);

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("AddPrep")]
        public async Task<IActionResult> AddPrep(string dishID, string mode, int watt, int temp, int rating, string notes, string magnetron)
        {
            Prep prep = new()
            {
                DishId = dishID,
                Mode = mode,
                Watt = watt,
                Temp = temp,
                Rating = rating,
                Notes = notes,
                Magnetron = magnetron
            };

            await _magnetronDAO.AddPrepAsync(prep);

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("AddMagnetron")]
        public async Task<IActionResult> AddMagnetron(string name)
        {
            MagnetronBrand magnetron = new()
            {
                Name = name
            };

            await _magnetronDAO.AddMagnetron(magnetron);

            return Ok();
        }
    }
}
