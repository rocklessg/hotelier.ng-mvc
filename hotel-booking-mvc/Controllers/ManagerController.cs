using Microsoft.AspNetCore.Mvc;

namespace hotel_booking_mvc.Controllers.Manager
{
    public class ManagerController : Controller
    {
        public IActionResult Dashboard()
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
