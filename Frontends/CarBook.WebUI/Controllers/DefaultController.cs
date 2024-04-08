using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5041/api/Location");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                List<SelectListItem> values2 = (from x in values select new SelectListItem { Text = x.locationName, Value = x.locationId.ToString() }).ToList();
                ViewBag.Locations = values2;
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public  IActionResult Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string locationId)
        {
            TempData["bookPickDate"] = book_pick_date;
            TempData["bookOffDate"] = book_off_date;
            TempData["timePick"] = time_pick;
            TempData["timeOff"] = time_off;
            
            int locationID = int.Parse(locationId);
            return RedirectToAction("Index", "RentACarList", new {id=locationID});
        }
    }
}
