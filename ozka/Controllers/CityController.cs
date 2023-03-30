using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ozka.Services.CityService;

namespace ozka.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CityController : ControllerBase
	{
		private readonly ICityService _cityService;

		public CityController(ICityService cityService)
        {
			_cityService = cityService;
		}

        [HttpGet]
		public async Task<ActionResult<List<City>>> GetAllCity()
		{
			return await _cityService.GetAllCity();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<List<City>>> GetCityById(int id)
		{
			var result = await _cityService.GetCityById(id);
			if (result is null)
				return NotFound("Sorry, but this city doesnt exist");
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<List<City>>> AddCity(City city)
		{
			var result = await _cityService.AddCity(city);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<List<City>>> UpdateCity(int id,City city)
		{
			var result = await _cityService.UpdateCity(id,city);
			if (result is null)
				return NotFound("Sorry, but this city doesnt exist");
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<City>>> DeleteCity(int id)
		{
			var result = await _cityService.DeleteCity(id);
			if (result is null)
				return NotFound("Sorry, but this city doesnt exist");
			return Ok(result);
		}
	}
}
