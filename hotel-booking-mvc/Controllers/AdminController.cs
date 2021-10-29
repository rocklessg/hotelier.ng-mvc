using hotel_booking_model;
using hotel_booking_model.ViewModels;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers.Admin
{
	public class AdminController : Controller
	{
		private readonly IHotelService _hotelService;
		private readonly IAdminService _adminService;

		public AdminController(IHotelService hotelService, IAdminService adminService)
		{
			_hotelService = hotelService;
			_adminService = adminService;
		}
		public async Task<IActionResult> Dashboard()
		{
			var result = await _adminService.ShowAdminDashboard();
			return View(result);
		}

		public async Task<IActionResult> HotelAsync(int pageNumber)
        {
            var hotelList = await _hotelService.GetAllHotelAsync(pageNumber);
            return View(hotelList);
        }     

		
		public IActionResult Manager()
		{
			return View();  
		}

		[HttpGet]
		public async Task<IActionResult> Transactions(int pageNumber, int pageSize)
		{
			var transactions = await _adminService.GetAllTransactions(pageSize, pageNumber);
			var app = transactions;
			return View(transactions);  
		}

		[HttpPost]
		public async Task<IActionResult> Transactions(int pageNumber, int pageSize, string searchQuery)
		{
			var transactions = await _adminService.GetAllTransactions(pageSize, pageNumber, searchQuery);
			var app = transactions;
			return View(transactions);  
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
