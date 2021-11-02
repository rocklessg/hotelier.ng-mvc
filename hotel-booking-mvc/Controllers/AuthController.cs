using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using hotel_booking_model.Dtos.AuthenticationDtos;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections;

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
                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken decodedValue = handler.ReadJwtToken(result.Token);
                Hashtable user = new Hashtable();
                user.Add("Id", decodedValue.Claims.ElementAt(0).Value);
                user.Add("FirstName", decodedValue.Claims.ElementAt(2).Value);
                user.Add("LastName", decodedValue.Claims.ElementAt(3).Value);
                user.Add("Avatar", decodedValue.Claims.ElementAt(4).Value);
                var Role = decodedValue.Claims.ElementAt(5).Value;
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                if (Role == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Details");
                    return View();
                }
                else if (Role == "Manager")
                {
                    return RedirectToAction("Dashboard", "Manager", new { managerId = result.Id });
                }
                else
                {
                    return RedirectToAction("Dashboard", "Admin");
                }     

            }
            return View(loginDto);
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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}


