using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointsOfInterestForUpdateDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You should provide a description for Name Property")]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
