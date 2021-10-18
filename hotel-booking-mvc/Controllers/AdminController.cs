using hotel_booking_model;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers.Admin
{
	public class AdminController : Controller
	{
		private readonly IHotelService _hotelService;

		public AdminController(IHotelService hotelService)
		{
			_hotelService = hotelService;
		}
        public IActionResult Dashboard()
        {
            TransactionPeriod transactionPeriod = new();
            //ViewData["transactionPeriod"] = transactionPeriod;
            return View(transactionPeriod);
        }
        public async Task<IActionResult> HotelAsync(int pageNumber)
        {
            var hotelList = await _hotelService.GetAllHotelAsync(pageNumber);
            return View(hotelList);
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
        public IActionResult HotelRooms()
        {
            return View();
        }
        public IActionResult AllManagers()
        {
            return View();
        }


        public IActionResult AllUsers()
        {
            return View();
        }
		public IActionResult HotelDetails(string hotelId)
		{
			return View();
		}

	}
}
