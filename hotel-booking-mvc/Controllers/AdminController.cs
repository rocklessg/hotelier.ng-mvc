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
		private readonly IManagerService _managerService;
	
		public AdminController(
			IHotelService hotelService, 
			IAdminService adminService,
			IManagerService managerService)
		{
			_hotelService = hotelService;
			_adminService = adminService;
			_managerService = managerService;
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

		public IActionResult Transactions()
		{
			return View();  
		}

		public IActionResult HotelRooms()
		{
			return View();
		}

		public async Task<IActionResult> AllManagers(string managerId, int? pageNumber)
		{
			var response = await _managerService.GetAllManagersAsync(pageNumber);
			
			if (response!=null)
            {
				ViewBag.SingleManager = null;
				var singleManager = response.PageItems.FirstOrDefault(x => x.ManagerId == managerId);
				ViewBag.SingleManager = singleManager ??= response.PageItems.FirstOrDefault();
				return View(response);
			}
            else
            {
				return View();
            }
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
