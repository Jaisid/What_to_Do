using What_to_Do.Models;
using What_to_Do.Models.DTOs;
using What_to_Do.Repositories.Interfaces;
using What_to_Do.Services.Interfaces;

namespace What_to_Do.Services.Implemenations
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task<IEnumerable<CityResponseDTO>> GetAllAsync()
        {
            var cities =  await _cityRepository.GetAllAsync();

            return cities.Select(x => new CityResponseDTO
            {
                id = x.Id,
                Name = x.Name
            });
        }

        public async Task<CityResponseDTO> GetByIdAsync(int id)
        {
           var city =  await _cityRepository.GetByIdAsync(id);
            if(city == null)
            {
                throw new Exception("City not found");
            }
            return new CityResponseDTO
            {
                id = city.Id,
                Name = city.Name
            };
        }

        public async Task CreateAsync(CreateCityDTO DTO)
        {
            var city = new City
            {
                Name = DTO.Name
            };
            await _cityRepository.AddAsync(city);
            await _cityRepository.saveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if(city == null)
            {
                throw new Exception("City not found");
            }
            await _cityRepository.DeleteAsync(city);
            await _cityRepository.saveChangesAsync();
        }

        public async Task UpdateAsync(int id,UpdateCityDTO dto)
        {
           var city =  await _cityRepository.GetByIdAsync(id);
            if (city == null)
                throw new Exception("City not Found");
            city.Name = dto.Name;
            await _cityRepository.UpdateAsync(city);
            await _cityRepository.saveChangesAsync();
        }
    }
}
