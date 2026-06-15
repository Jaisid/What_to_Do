using Microsoft.EntityFrameworkCore;
using What_to_Do.DataBaseContext;
using What_to_Do.Models;
using What_to_Do.Repositories.Interfaces;

namespace What_to_Do.Repositories.Implemention
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationContext _context;

        public CityRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task AddAsync(City city)
        {
             await _context.Cities.AddAsync(city);
        }

        public async Task UpdateAsync(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(City city)
        {       
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Cities.AnyAsync(x=>x.Id == id);
        }

        public async Task saveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
