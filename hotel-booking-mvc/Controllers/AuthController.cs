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
<<<<<<< HEAD
using hotel_booking_model.ViewModels;
=======
using hotel_booking_mvc.CustomAuthorization;
>>>>>>> aa94faf3d2e47df6af8806a1567c5147b0a2fffa

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

                if (result == null && !response.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                    return View();
                }

                var user = new Hashtable
                {
                    { "Id", result.Claims.ElementAt(0).Value },
                    { "FirstName", result.Claims.ElementAt(2).Value },
                    { "LastName", result.Claims.ElementAt(3).Value },
                    { "Avatar", result.Claims.ElementAt(4).Value }
                };

                var Role = result.Claims.ElementAt(5).Value;
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

        [HttpGet]
        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost("updatePassword")]
        [CustomAuthenticationFilter(roles: new string[] { "Admin", "Manager" })]
        public IActionResult UpdatePassword(UpdatePasswordDto obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var response = _auth.UpdatePassword(obj);
                ViewBag.Data = response.Result;
                return View();
            }
            catch (Exception)
            {
                TempData["error"] = "Oops something bad happened try again!";
                return View();
            }
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

        public IActionResult ManagerRequest(MgrReqViewModel mgrReqViewModel)
        {
            return View(mgrReqViewModel);
        }
    }
}


