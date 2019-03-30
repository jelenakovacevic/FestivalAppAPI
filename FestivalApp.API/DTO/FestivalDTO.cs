using System;
using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTO
{
    public class FestivalDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LocationLatitude { get; set; }
        public string LocationLongitude { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string NumberOfRates { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        [Required]
        public int FestivalTypeId { get; set; }
    }
}