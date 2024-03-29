using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5041/api/Car/GetCarsWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task< IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5041/api/Brand");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                List<SelectListItem> brandValues = (from x in values
                                                    select new SelectListItem
                                                    {

                                                        Text = x.brandName,
                                                        Value = x.brandId.ToString()


                          
                                                    }).ToList();
                ViewBag.BrandValues = brandValues;
                return View();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5041/api/Car", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
            ;
        }
        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5041/api/Car/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client=  _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5041/api/Car/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                var brandResponseMessage = await client.GetAsync("http://localhost:5041/api/Brand");
                if (brandResponseMessage.IsSuccessStatusCode)
                {

                    var brandJsonData = await brandResponseMessage.Content.ReadAsStringAsync();
                    var brandValues = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJsonData);
                    List<SelectListItem> brandvalues = (from x in brandValues select new SelectListItem { Text=x.brandName, Value=x.brandId.ToString()}).ToList();
                    ViewBag.brandValues = brandvalues;
                    return View(values);

                }

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync($"http://localhost:5041/api/Car/", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            var brandResponseMessage = await client.GetAsync("http://localhost:5041/api/Brand");
            if(brandResponseMessage.IsSuccessStatusCode)
            {
                var brandjsonData = await brandResponseMessage.Content.ReadAsStringAsync();
                var brandvalues = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandjsonData);

                List<SelectListItem> brandValues= (from x in brandvalues select new SelectListItem { Text=x.brandName, Value=x.brandId.ToString()}).ToList();
                ViewBag.brandValues = brandvalues;
                
            }
            return View();
        }
    }
}
