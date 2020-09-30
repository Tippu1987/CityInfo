using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [Route("{id}",Name ="RouteParam")]
        public IActionResult GetpointOfInterest(int cityId, int id)
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

        [HttpPost]
        public IActionResult CreatePointOfInterest(int cityId, PointsOfInterestForCreationDTO pointOfInterest)
        {
            //For any complex validations like checking if name==description or if same POI is added earlier..we can check Fluent Validation here..
            //https://fluentvalidation.net/
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
                return NotFound();
            int nextId = city.PointsOfInterest.Max(x => x.Id) + 1;
            PointsOfInterestDTO finalpoi = new PointsOfInterestDTO
            {
                Id = nextId,
                Description = pointOfInterest.Description,
                Name = pointOfInterest.Name
            };
            city.PointsOfInterest.Add(finalpoi);

            return CreatedAtRoute("RouteParam",
                new { cityId, finalpoi.Id },
                finalpoi);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePointOfInterest(PointsOfInterestForUpdateDTO pointsOfInterest, int cityId, int id)
        {
            if (pointsOfInterest.Name == pointsOfInterest.Description)
                ModelState.AddModelError("Description", "Name and Description cannot be the Same");
            if (!ModelState.IsValid)
                return BadRequest();
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            var poi = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
            if (city == null || poi == null)
                return NotFound();
            poi.Name = pointsOfInterest.Name;
            poi.Description = pointsOfInterest.Description;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            var poi = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
            if (city == null || poi == null)
                return BadRequest();
            city.PointsOfInterest.Remove(poi);
            return NoContent();
        }
    }
}
