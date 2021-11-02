using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using hotel_booking_mvc.CustomAuthorization;

namespace hotel_booking_mvc.Controllers.Admin
{
	[CustomAuthenticationFilter(roles: new string[] { "Admin" })]
	public class AdminController : Controller
	{
		private readonly IHotelService _hotelService;
		private readonly IAdminService _adminService;
		private readonly IManagerService _managerService;
		private readonly IReviewService _reviewService;
	
		public AdminController(IHotelService hotelService, IAdminService adminService,
			IManagerService managerService, IReviewService reviewService)
		{
			_hotelService = hotelService;
			_adminService = adminService;
			_managerService = managerService;
			_reviewService = reviewService;
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
		public async Task<IActionResult> HotelDetails(string hotelId)
		{
			var singleHotel = await _hotelService.GetHotelById(hotelId);
			ViewData["GetHotel"] = singleHotel;
			return View();
		}

	
		public IActionResult Account()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Account(UserDto userDto)
		{
			return View();
		}


		[HttpGet]
		public IActionResult GetReviews(string hotelId)
		{
			var reviews = _reviewService.GetHotelReviews(hotelId);
			return View(reviews);
		}
		
	}
}
