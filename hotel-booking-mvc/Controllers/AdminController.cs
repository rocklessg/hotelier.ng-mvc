using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers.Admin
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult HotelDetails()
        {
            return View("../Hotel/Details");
        }

        public IActionResult SingleRoom()
        {
            return View("../Hotel/SingleRoom");
        }
    }
}
