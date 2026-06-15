using System.ComponentModel.DataAnnotations;

namespace What_to_Do.Models.DTOs
{
    public class CreateCityDTO
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
