using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_model.ViewModels;
using hotel_booking_mvc.CustomAuthorization;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers.Manager
{
    [CustomAuthenticationFilter(roles: new string[] { "Manager" })]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IHotelService _hotelService;



        public ManagerController(IHotelService hotelService, IManagerService managerService)

        {

            _hotelService = hotelService;
            _managerService = managerService;
        }

        public async Task<IActionResult> DashboardAsync(string managerId)
        {
            TempData["managerId"] = managerId;
            var result = await _managerService.ShowManagerDashboard(managerId);
            return View(result);
        }

        public async Task<IActionResult> HotelAsync(string managerId)
        {
            TempData["managerId"] = managerId;
            var paginationResponse = await _hotelService.GetAllHotelForManagerAsync(managerId);
            return View(paginationResponse);
        }

        public IActionResult Bookings()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Transactions(int pageNumber, int pageSize)
        {

            var loggedinUser = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<AuthenticatedDto>(loggedinUser);

            var managerTransactionsList = await _managerService.GetAllManagerTransactionsAsync(user.Id, pageSize, pageNumber);
            return View(managerTransactionsList);
        }
        [HttpPost]
        public async Task<IActionResult> Transactions(int pageNumber, int pageSize, string searchQuery)
        {

            var loggedinUser = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<AuthenticatedDto>(loggedinUser);

            var managerTransactionsList = await _managerService.GetAllManagerTransactionsAsync(user.Id, pageSize, pageNumber, searchQuery);
            return View(managerTransactionsList);
        }
        public async Task<IActionResult> HotelRooms(string roomTypeId)
        {
            var result = await _hotelService.GetRoomTypeDetails(roomTypeId);
            return View(result);
        }

        public async Task<IActionResult> HotelDetails(string hotelId)
        {
            var singleHotel = await _hotelService.GetHotelById(hotelId);
            ViewData["GetHotel"] = singleHotel;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Account()
        {
            var loggedInUser = HttpContext.Session.GetString("User");

            var user = JsonConvert.DeserializeObject<LoggedInUserViewModel>(loggedInUser);
            var manager = await _managerService.GetManagerById(user.Id);
            manager.Id = user.Id;

            //ViewData["Manager"] = manager;
            return View(manager);
        }


        [HttpPost]
        public async Task<IActionResult> Account(EditManagerViewModel model)
        {
            var loggedInUser = HttpContext.Session.GetString("User");
            var user = JsonConvert.DeserializeObject<LoggedInUserViewModel>(loggedInUser);
            model.Id = user.Id;

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid data entry");
                return View();
            }
            else
            {
                var response = await _managerService.EditManagerAccountAsync(model);

                return RedirectToAction("Dashboard", "Manager", new { ManagerId = model.Id });
            }
          
        }
       

        //public async Task<IActionResult> UpdateManagerDetails(string managerId)
        //{
        //    var result = await _managerService.GetManagerById(managerId);
        //    return View(result);
        //}
      
    }
}
