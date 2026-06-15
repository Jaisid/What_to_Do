using System.ComponentModel.DataAnnotations;
namespace What_to_Do.Models.DTOs
{
    public class CityResponseDTO
    {
        public int id { get; set; }
        public string? Name
        {
            get; set;
        }
    }
}
