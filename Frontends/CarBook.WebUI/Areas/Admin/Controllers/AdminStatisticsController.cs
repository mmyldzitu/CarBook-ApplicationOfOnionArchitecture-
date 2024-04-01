using CarBook.Dto.StatisticsDtos;
using CarBook.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task< IActionResult> Index()
        {
            Random random = new Random();
            ResultStatisticsModel statisticsModel= new ResultStatisticsModel();
            var client = _httpClientFactory.CreateClient();

            int rand1 = random.Next(0,101);
            var responseMessage1 = await client.GetAsync("http://localhost:5041/api/Statistics/GetCarsCount");
            var jsonData1= await responseMessage1.Content.ReadAsStringAsync();
            var value1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
            statisticsModel.CarCount = value1!.carCount;
            statisticsModel.CarCountRand = rand1;

            int rand2 = random.Next(0, 101);
            var responseMessage2 = await client.GetAsync("http://localhost:5041/api/Statistics/GetAuthorCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var value2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
            statisticsModel.AuthorCount = value2!.authorCount;
            statisticsModel.AuthorCountRand = rand2;

            int rand3 = random.Next(0, 101);
            var responseMessage3 = await client.GetAsync("http://localhost:5041/api/Statistics/GetBlogsCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var value3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
            statisticsModel.BlogCount = value3!.blogCount;
            statisticsModel.BlogCountRand = rand3;

            int rand4 = random.Next(0, 101);
            var responseMessage4 = await client.GetAsync("http://localhost:5041/api/Statistics/GetBrandsCount");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            var value4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
            statisticsModel.BrandCount = value4!.brandCount;
            statisticsModel.BrandCountRand = rand4;

            int rand5 = random.Next(0, 101);
            var responseMessage5 = await client.GetAsync("http://localhost:5041/api/Statistics/GetCarCountByElectric");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            var value5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
            statisticsModel.CarCountByElectric = value5!.carCount;
            statisticsModel.CarCountByElectricRand = rand5;

            int rand6 = random.Next(0, 101);
            var responseMessage6 = await client.GetAsync("http://localhost:5041/api/Statistics/GetCarCountByGasolineOrDiesel");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            var value6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
            statisticsModel.CarCountByGasolineOrDiesel = value6!.carCount;
            statisticsModel.CarCountByGasolineOrDieselRand = rand6;

            int rand7 = random.Next(0, 101);
            var responseMessage7 = await client.GetAsync("http://localhost:5041/api/Statistics/GetCarCountByTransmissionIsAuto");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            var value7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
            statisticsModel.CarCountByTransmissionIsAuto = value7!.carCount;
            statisticsModel.CarCountByTransmissionIsAutoRand = rand7;

            int rand8 = random.Next(0, 101);
            var responseMessage8 = await client.GetAsync("http://localhost:5041/api/Statistics/GetCarCountByKmLessThan1000");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            var value8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
            statisticsModel.CarCountByKmLessThan1000 = value8!.carCount;
            statisticsModel.CarCountByKmLessThan1000Rand = rand8;

            int rand9 = random.Next(0, 101);
            var responseMessage9 = await client.GetAsync("http://localhost:5041/api/Statistics/GetLocationCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            var value9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
            statisticsModel.LocationCount = value9!.locationCount;
            statisticsModel.LocationRand = rand9;

            int rand10 = random.Next(0, 101);
            var responseMessage10 = await client.GetAsync("http://localhost:5041/api/Statistics/GetMostCommentBlog");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            var value10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
            statisticsModel.MostCommentBlog = value10!.blogName;
            statisticsModel.MostCommentBlogRand = rand10;

            int rand11 = random.Next(0, 101);
            var responseMessage11 = await client.GetAsync("http://localhost:5041/api/Statistics/GetMostCountBrand");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            var value11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
            statisticsModel.MostCountBrand = value11!.brandName;
            statisticsModel.MostCountBrandRand = rand11;

            int rand12 = random.Next(0, 101);
            var responseMessage12 = await client.GetAsync("http://localhost:5041/api/Statistics/GetBrandAndModelDailyPriceIsMin");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            var value12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
            statisticsModel.BrandAndModelDailyPriceIsMin = value12!.brandAndModelName;
            statisticsModel.BrandAndModelDailyPriceIsMinRand = rand12;

            int rand13 = random.Next(0, 101);
            var responseMessage13 = await client.GetAsync("http://localhost:5041/api/Statistics/GetBrandAndModelDailyPriceIsMax");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            var value13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
            statisticsModel.BrandAndModelDailyPriceIsMax = value13!.brandAndModelName;
            statisticsModel.BrandAndModelDailyPriceIsMaxRand = rand13;

            int rand14 = random.Next(0, 101);
            var responseMessage14 = await client.GetAsync("http://localhost:5041/api/Statistics/GetDailyAveragePrice");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            var value14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
            statisticsModel.DailyAveragePrice = value14!.price.ToString("0.00");
            statisticsModel.DailyAveragePriceRand = rand14;

            int rand15 = random.Next(0, 101);
            var responseMessage15 = await client.GetAsync("http://localhost:5041/api/Statistics/GetWeeklyAveragePrice");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            var value15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
            statisticsModel.WeeklyAveragePrice = value15!.price.ToString("0.00");
            statisticsModel.WeeklyAveragePriceRand = rand15;

            int rand16 = random.Next(0, 101);
            var responseMessage16 = await client.GetAsync("http://localhost:5041/api/Statistics/GetMonthlyAveragePrice");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            var value16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
            statisticsModel.MonthlyAveragePrice =value16!.price.ToString("0.00");
            statisticsModel.MonthlyAveragePriceRand = rand16;



            return View(statisticsModel);
        }
    }
}
