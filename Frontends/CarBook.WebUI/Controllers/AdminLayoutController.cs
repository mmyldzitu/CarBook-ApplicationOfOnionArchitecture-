using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task <PartialViewResult> AdminHeaderPartial()
        {

            return PartialView();
        }
        public async Task<PartialViewResult> AdminNavbarPartial()
        {

            return  PartialView();
        }
        public async Task<PartialViewResult> AdminSideBarPartial()
        {

            return PartialView();
        }
        public async Task<PartialViewResult> AdminFooterPartial()
        {

            return PartialView();
        }
        public async Task<PartialViewResult> AdminScriptPartial()
        {

            return PartialView();
        }


    }
}
