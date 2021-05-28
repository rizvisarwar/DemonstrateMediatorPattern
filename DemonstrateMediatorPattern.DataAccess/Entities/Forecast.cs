using System;
using System.ComponentModel.DataAnnotations;

namespace DemonstrateMediatorPattern.DataAccess.Entities
{
    public class Forecast
    {
        public DateTime Date { get; set; }

        [Required]
        public int TemperatureC { get; set; }

        [Required]
        public string Summary { get; set; }
    }
}
