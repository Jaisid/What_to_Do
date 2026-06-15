using System.ComponentModel.DataAnnotations;

namespace What_to_Do.Models.DTOs
{
    public class UpdateCityDTO
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
