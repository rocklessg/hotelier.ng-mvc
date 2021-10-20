using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using hotel_booking_model.Dtos.AuthenticationDtos;

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
        public async Task<IActionResult> Login(LoginDto loginModel)
        {
            var handler = new JwtSecurityTokenHandler();


            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _auth.Login(loginModel);

                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(result));
                    JwtSecurityToken decodedValue = handler.ReadJwtToken(result.Token);
                    var Claim = decodedValue.Claims.ElementAt(2);
                    if (Claim.Value == "Manager")
                    {
                        return RedirectToAction("Dashboard", "Manager");
                    }
                    return RedirectToAction("Dashboard", "Admin");
                }
                catch (Exception)
                {
                    TempData["error"] = "Oops something bad happened try again!";
                    return View();
                }
            }
            return View();
        }
      


        [HttpPost]
        public IActionResult Signup()
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            //try
            //{
            //    var result = _auth.Signup(signupmodel);


            //    return RedirectToAction("Login");
            //}
            //catch (Exception)
            //{
            //    TempData["error"] = "Oops something bad happened try again!";
            //    return View();
            //}
            return View();
        }




        //public IActionResult Signup()
        //{
        //    return View();
        //}



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
