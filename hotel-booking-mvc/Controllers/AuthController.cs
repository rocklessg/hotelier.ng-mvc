using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using hotel_booking_model.Dtos.AuthenticationDtos;
using System.Threading.Tasks;


namespace hotel_booking_mvc.Controllers.Auth
{
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _auth;
        public AuthController(IAuthenticationService auth)
        {
            _auth = auth;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _auth.Login(loginDto);
                var result = response.Data;
                var role = result.Claim.Value; 
                
                if (result == null)
                {
                    TempData["error"] = response.Message;
                    return View();
                }


                if (role == "Manager")
                {
                    return RedirectToAction("Dashboard", "Manager");
                }
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var result = _auth.Register(registerDTO);
                // result.EnsureSuccessStatusCode();
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                TempData["error"] = "Oops something bad happened try again!";
                return View();
            }
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


