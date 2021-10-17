using hotel_booking_model;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers.Manager
{
    public class ManagerController : Controller
    {
        private readonly IHotelService _hotelService;

        public ManagerController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AllManagers()
        {
            return View();
        }

        public async Task<IActionResult> HotelAsync(string managerId)
        {
            var hotelList = await _hotelService.GetAllHotelForManagerAsync(managerId);
            return View(hotelList);
        }

        public IActionResult Bookings()
        {
            return View();
        }

        public IActionResult Transactions()
        {
            return View();
        }
        public IActionResult SingleRoom()

        {
            return View();
        }

        public IActionResult HotelDetails()

        {
            return View();
        }
    }
}
