using EntityLayer;

namespace ozka.Services.CityService
{
	public interface ICityService
	{
		Task<List<City>> GetAllCity();
		Task<City> GetCityById(int id);
		Task<List<City>> AddCity(City city);
		Task<List<City>> UpdateCity(int id, City city);
		Task<List<City>> DeleteCity(int id);
	}
}
