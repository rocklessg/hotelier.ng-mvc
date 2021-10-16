using Microsoft.AspNetCore.Mvc;

namespace hotel_booking_mvc.Controllers
{
    public class LandingViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
