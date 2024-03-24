using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
       

        public  IActionResult Index()
        {
            ViewBag.v1 = "Servisler";
            ViewBag.v2 = "Servislerimiz";
           
            return View();
        }
    }
}
