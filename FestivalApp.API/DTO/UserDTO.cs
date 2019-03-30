using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int Age { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        [Required]
        public string Role { get; set; }
        public string Image { get; set; }
    }
}