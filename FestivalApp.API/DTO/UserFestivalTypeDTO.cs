using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTO
{
    public class UserFestivalTypeDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
    }
}