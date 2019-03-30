using System.ComponentModel.DataAnnotations;

namespace FestivalApp.API.DTO
{
    public class FestivalTypeDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
    }
}