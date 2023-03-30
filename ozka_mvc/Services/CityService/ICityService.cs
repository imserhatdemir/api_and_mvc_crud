using EntityLayer;

namespace ozka_mvc.Services.CityService
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City> GetCityAsync(int id);
        Task<List<City>> AddCityAsync(City city);
        Task<bool> UpdateCityAsync(City city, int id);
        Task<bool> DeleteCityAsync(int id);
    }
}
