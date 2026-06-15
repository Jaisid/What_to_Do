using What_to_Do.Models;

namespace What_to_Do.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<City> GetByIdAsync(int id);
        Task AddAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(City city);
        Task<bool> ExistAsync(int id);
        Task saveChangesAsync();
    }
}
