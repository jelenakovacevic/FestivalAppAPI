using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTO
{
    public class UserUpdateDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string AboutMe { get; set; }
    }
}