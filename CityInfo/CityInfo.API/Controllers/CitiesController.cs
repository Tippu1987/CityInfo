using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPatch]
        [Route("{cityId}")]
        public IActionResult PatchCity([FromBody] JsonPatchDocument<CityDTO> cityModel, [FromRoute] int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            cityModel.ApplyTo(city);
            return Ok();
        }
    }
}
