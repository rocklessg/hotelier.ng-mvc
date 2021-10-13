using hotel_booking_model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult HotelDetails()
        {
            return View("../Hotel/Details");
        }

        public IActionResult SingleRoom()
        {
            return View("../Hotel/SingleRoom");
        }

        public IActionResult AllHotels(int pageNumber)
        {
            var hotel = new HotelBasicView
            {
                Id = "Favelewkew",
                Rating = 4.5,
                Name = "The Croniche Hotel Bistro",
                Description = "Offering an outdoor pool and a restaurant, Sheraton Lagos Hotel is located in Lagos. Free WiFi access is available. Each room here will provide you with a TV, air conditioning and a seating area.",
                FeaturedImage = "https://s3-alpha-sig.figma.com/img/2b59/1574/6b2c85ee661a6c49cb920c969ad4c0c0?Expires=1634515200&Signature=K8kRMAa2d6ySoD1XJcIR0OSGx3o-hCCMR~VZZ~9ppVyjJLUVf0mAJydp4UAlaAk1AO6LUxxYCxHmguxYt4yKyuw-biREhgRMae7Dj4p3VuDj2ZUrWuTLshK5MH-teTG-X0J3tS-7sD6Iu6BmWrrOSrgLF4XcDrUMYFdmFjWmt2~-0E6lghkwa8J~VMq7qmQzmsf3mn3ZTvwMWtItMKj2mL0QIsV~7CyWcuFxG-by41typSXut4yLOkXGJkMc1xetuIZcUfRS1HBnAFU8sDFn~R7p83bavKKpRBNJX1EH2k5DHCEfi1xU9cNjuZ7zL6C2dGZftKvQk1PRajROWm3l9w__&Key-Pair-Id=APKAINTVSUGEWH5XD5UA",
                Address = "Abel Oreniyi street off Salvation Road Opebi",
                State ="Lagos",
                City ="IKeja",
                NumberOFRatings = 209                
            };
            var hotelList = new List<HotelBasicView>();
            for (int i = 0; i < 5; i++)
            {
                hotelList.Add(hotel);
            }
            return View("../hotel/allhotels",hotelList);
        }
    }
}
