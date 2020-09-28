using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDTO> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CityDTO>
            {
                new CityDTO{Id=1,Name="Phoenix",Description="A Very hot Summer City",
                    PointsOfInterest =
                    {
                        new PointsOfInterestDTO{Id=1,Description="A variety of Animals in Phoenix Zoo",Name="Phoenix Zoo"},
                        new PointsOfInterestDTO{Id=2,Description="A Canyon Carved by River Colorado",Name="Grand Canyon"},
                        new PointsOfInterestDTO{Id=3,Description="Excellent Winter Resort to escape Heat",Name="Flagstaff"}
                    }
                },
                new CityDTO{Id=2,Name="Austin",Description="Number of Indians are very high",
                PointsOfInterest =
                    {
                        new PointsOfInterestDTO{Id=1,Description="San Marcos Mall",Name="San Marcos"},
                        new PointsOfInterestDTO{Id=2,Description="An Amusement Park",Name="Pleasure Pier"}
                    }},
                new CityDTO{Id=3,Name="New York City",Description="Eastern Pearl City",
                PointsOfInterest =
                    {
                        new PointsOfInterestDTO{Id=1,Description="A 102 story tower",Name="Manhattan"},
                        new PointsOfInterestDTO{Id=2,Description="A Giant Aquarium",Name="Sea World"}
                    }},
                new CityDTO{Id=4,Name="Seattle",Description="Rainy in 9 months of the Year",
                PointsOfInterest =
                    {
                        new PointsOfInterestDTO{Id=1,Description="Very Rainy Winters",Name="Rain Forest"},
                        new PointsOfInterestDTO{Id=2,Description="Microsoft Giant Campus",Name="Microsoft Campus"}
                    }
                },
                new CityDTO{Id=5,Name="Chicago",Description="Largest Airport",
                PointsOfInterest =
                    {
                        new PointsOfInterestDTO{Id=1,Description="Bull Market",Name="Very Ice Cold Place"},
                        new PointsOfInterestDTO{Id=2,Description="Happening Place",Name="Mill Avenue"}
                    }}
            };
        }
    }
}
