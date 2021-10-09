using hotel_booking_model;
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
            TransactionPeriod transactionPeriod = new TransactionPeriod();
            //ViewData["transactionPeriod"] = transactionPeriod;
            return View(transactionPeriod);
        }

        // Hotel Listing Controller
        public IActionResult Hotel()
        {
            return View();
        }

        // Manager Listing Controller
        public IActionResult Manager()
        {
            return View();  

        }

        public IActionResult Transactions()
        {
            return View();  
        }

        public IActionResult HotelDetails()
        {
            return View();
        }

       
    }
}
