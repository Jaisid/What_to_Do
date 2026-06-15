using What_to_Do.Models.DTOs;

namespace What_to_Do.Services.Interfaces
{
    public interface ICityService
    {
        Task <IEnumerable<CityResponseDTO>> GetAllAsync ();
        Task <CityResponseDTO> GetByIdAsync (int id);
        Task CreateAsync(CreateCityDTO city);
        Task UpdateAsync(int id, UpdateCityDTO dto);
        Task DeleteAsync (int id);

    }
}
