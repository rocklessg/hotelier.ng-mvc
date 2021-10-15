using Microsoft.AspNetCore.Mvc;

namespace hotel_booking_mvc.Controllers.Auth
{
    public class AuthController : Controller
    {
        public AuthController()
        {

        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult ForgotPassword()
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
