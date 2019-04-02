using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTO
{
    public class FestivalDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string LocationLatitude { get; set; }
        [Required]
        public string LocationLongitude { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string NumberOfRates { get; set; }
        public string Image { get; set; }
        [Required]
        public string Address { get; set; }
        public string TimeStart { get; set; }
        [Required]
        public int FestivalTypeId { get; set; }
        public List<UserDTO> Users { get; set; }
    }
}