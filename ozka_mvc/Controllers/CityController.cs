using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ozka_mvc.Services.CityService;

namespace ozka_mvc.Controllers
{
    public class CityController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICityService _cityService;

        public CityController(IHttpClientFactory clientFactory, ICityService cityService)
        {
            _clientFactory = clientFactory;
            _cityService = cityService;
        }
        public async Task<IActionResult> Index()
        {
            var sehirler = await _cityService.GetCitiesAsync();
            return View(sehirler);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                var response = await _cityService.AddCityAsync(city);
                return RedirectToAction("Index");
            }
            return View(city);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var city = await _cityService.GetCityAsync(id.Value);

                if (city == null)
                {
                    return NotFound();
                }

                return View(city);
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, City city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _cityService.UpdateCityAsync(city, id);
                    return RedirectToAction("Index");
                }
                catch (HttpRequestException)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the city.");
                }
            }
            return View(city);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var city = await _cityService.GetCityAsync(id.Value);

                if (city == null)
                {
                    return NotFound();
                }

                return View(city);
            }
            catch (HttpRequestException)
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isSuccessful = await _cityService.DeleteCityAsync(id);

            if (isSuccessful)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete", new { id, errorMessage = "Silme işlemi başarısız." });

        }
    }
}
