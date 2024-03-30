using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/AdminLocation")]
    public class AdminLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5041/api/Location");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateLocation")]
        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }
        [Route("CreateLocation")]

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5041/api/Location", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation");
            }
            return View();
        }
        [Route("UpdateLocation/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5041/api/Location/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("UpdateLocation/{id}")]

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5041/api/Location", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation");
            }
            return View();
        }
        [Route("DeleteLocation/{id}")]

        public async Task<IActionResult> DeleteLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5041/api/Location/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation");
            }
            return View();
        }
    }
}
