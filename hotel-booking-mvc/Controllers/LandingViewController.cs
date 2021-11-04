using hotel_booking_model.commons;
using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_model.ViewModels;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using hotel_booking_mvc.CustomAuthorization;
using System.Security.Claims;

namespace hotel_booking_mvc.Controllers
{
    public class LandingViewController : Controller
    {
        private readonly IHotelService _hotelService;
        public LandingViewController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var hotels = await _hotelService.GetTopHotelsAsync();
            var loggedinUser = HttpContext.Session.GetString("User");
            ViewData["LoggedInUser"] = loggedinUser;
            var role = HttpContext.Session.GetString("role");
            ViewData["Role"] = role;
            return View(hotels);
        }
    }
}
