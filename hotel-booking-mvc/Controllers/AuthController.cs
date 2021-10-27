using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using hotel_booking_model.Dtos.AuthenticationDtos;
using System.Threading.Tasks;


namespace hotel_booking_mvc.Controllers.Auth
{
    public class AuthController : Controller
    {

        private readonly IAuthenticationService _auth;
        public static string role = string.Empty;

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

                if (result == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Details");
                    return View();
                }

                role = result.Claim.Value;
                if (role == "Manager")
                {
                    return RedirectToAction("Dashboard", "Manager");
                }
                else
                {
                    return RedirectToAction("Dashboard", "Admin");
                }

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
                //  result.EnsureSuccessStatusCode();
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

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email) 
        {
            var result = await _auth.ForgotPassword(email);
            ViewBag.Data = "Kindly check your email for a password recovery link";
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

        public IActionResult UpdatePassword() 
        {
            return View();
        }

        

        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDto model)
        {
            ViewBag.Role = role;


            if (model.NewPassword == model.ConfirmPassword) 
            {
                var result = await _auth.UpdatePassword(model);
                ModelState.Clear();
                ViewBag.Data = result;
                return View();

            }

            ModelState.Clear();
            ViewBag.Data = "The new password and current password must match";
            return View();


        }



    }
}
