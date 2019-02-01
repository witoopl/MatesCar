using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatesCarSite.Models
{
    public enum CarBrand
    {
        Volvo, Audi, Volkswagen, Renault, Citroen, Opel, BMW
    }
    public class Car
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public CarBrand Brand { get; set; }
        [MaxLength(32, ErrorMessage = "Name of the car model is too long", ErrorMessageResourceName ="TooLongModelName")]
        public string Model { get; set; }
        [Required]
        public byte NumberOfSeats { get; set; }
        [Required]
        public float FuelConsumptionGeneral { get; set; }
        public float? FuelConsumptionInCity { get; set; }
        public float? FuelConsumptionForRoad { get; set; }


    }
}
