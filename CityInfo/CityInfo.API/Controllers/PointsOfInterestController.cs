using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController:ControllerBase
    {
        [HttpGet]
        public IActionResult GetPointsOfInterestForCity(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
                return NotFound();
            else
                return Ok(city.PointsOfInterest);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult getpointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
                return NotFound();
            else
            {
                var poi = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
                if (poi == null)
                    return NotFound();
                else
                    return Ok(poi);
            }
        }
    }
}
