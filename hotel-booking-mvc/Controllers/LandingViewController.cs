using Microsoft.AspNetCore.Mvc;
using hotel_booking_model.ViewModels;

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
