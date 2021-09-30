using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers
{
    public class LandingViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
