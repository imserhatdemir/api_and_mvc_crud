using EntityLayer;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ozka_mvc.Services.CityService
{
    public class CityService : ICityService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CityService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        private HttpClient GetClient()
        {
            return _clientFactory.CreateClient("ozka_api");
        }
        public async Task<List<City>> AddCityAsync(City city)
        {
            var client = GetClient();
            var response = await client.PostAsJsonAsync("api/City/", city);

            if (response.IsSuccessStatusCode)
            {
                var sehirler = JsonConvert.DeserializeObject<List<City>>(await response.Content.ReadAsStringAsync());
                return sehirler;
            }
            else
            {
                throw new HttpRequestException($"Error adding city: {response.StatusCode}");
            }
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"api/City/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/City");
            var sehirler = JsonConvert.DeserializeObject<List<City>>(await response.Content.ReadAsStringAsync());
            return sehirler;
        }

        public async Task<City> GetCityAsync(int id)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/City/{id}");

            if (response.IsSuccessStatusCode)
            {
                var city = JsonConvert.DeserializeObject<City>(await response.Content.ReadAsStringAsync());
                return city;
            }
            else
            {
                throw new HttpRequestException($"Error retrieving city: {response.StatusCode}");
            }
        }

        public async Task<bool> UpdateCityAsync(City city, int id)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync($"api/City/{id}", city);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException($"Error updating city: {response.StatusCode}");
            }
        }
    }
}
