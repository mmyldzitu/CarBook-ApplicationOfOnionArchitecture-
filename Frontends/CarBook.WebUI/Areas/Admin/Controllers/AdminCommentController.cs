using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using CarBook.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController:Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5041/api/Comment/GetCommentByBlogId/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                var responseMessage2 = await client.GetAsync($"http://localhost:5041/api/Blog/GetBlogName/{id}");
                if(responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2= await responseMessage2.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<ResultBlogNameDto>(jsonData2);
                    return View( new CommentByBlogIdViewModel { blogName=value?.blogName, Comments=values });
                }
                
                
            }
            return View();
        }
    }
}
