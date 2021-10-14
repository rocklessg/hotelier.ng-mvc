using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers.Manager
{
    public class ManagerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }


        public IActionResult AllManagers()
        {
            return View();
        }
        
        public IActionResult Hotel()
        {
            return View();
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
    }
}
