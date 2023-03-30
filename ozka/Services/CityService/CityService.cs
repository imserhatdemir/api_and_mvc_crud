using EntityLayer;
using Microsoft.EntityFrameworkCore;
using ozka.Data;
namespace ozka.Services.CityService
{
	public class CityService : ICityService
	{
		private readonly Context _context;

		public CityService(Context context)
        {
			_context = context;
		}
        public async Task<List<City>> AddCity(City city)
		{
			_context.Cities.Add(city);
			await _context.SaveChangesAsync();
			return await _context.Cities.ToListAsync();
		}

		public async Task<List<City>> DeleteCity(int id)
		{
			var cityes = await _context.Cities.FindAsync(id);
			if (cityes is null)
				return null;
			_context.Cities.Remove(cityes);
			await _context.SaveChangesAsync();
			return await _context.Cities.ToListAsync();
		}

		public async Task<List<City>> GetAllCity()
		{
			return await _context.Cities.ToListAsync();
		}

		public async Task<City> GetCityById(int id)
		{
			var city = await _context.Cities.FindAsync(id);
			if (city is null)
				return null;
			return city;
		}

		public async Task<List<City>> UpdateCity(int id, City city)
		{
			var cityes = await _context.Cities.FindAsync(id);
			if (cityes is null)
				return null;

			cityes.City_name = city.City_name;
			cityes.Country = city.Country;

			await _context.SaveChangesAsync();
			return await _context.Cities.ToListAsync();
		}
	}
}
