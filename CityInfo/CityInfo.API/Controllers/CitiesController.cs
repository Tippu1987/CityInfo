using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id);
            if (city == null)
                return NotFound();
            else
                return Ok(city);
        }
    }
}
