using Microsoft.AspNetCore.Mvc;

namespace hotel_booking_mvc.Controllers
{
    public class PasswordResetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ConfirmEmail()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
