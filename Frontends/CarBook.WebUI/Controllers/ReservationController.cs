using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.v1 = "Araç Kiralam";
            ViewBag.v2 = "Rezervasyon Formu";
            return View();
        }
    }
}
