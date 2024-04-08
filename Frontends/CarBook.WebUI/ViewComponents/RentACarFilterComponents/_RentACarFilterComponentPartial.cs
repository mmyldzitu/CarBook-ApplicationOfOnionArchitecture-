using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial:ViewComponent
    {
        public async Task< IViewComponentResult >InvokeAsync()
        {
            return View();

        }
    }
}
