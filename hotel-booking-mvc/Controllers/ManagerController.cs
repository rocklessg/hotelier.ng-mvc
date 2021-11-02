using hotel_booking_model;
using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using hotel_booking_model.Dtos.AuthenticationDtos;
using Newtonsoft.Json;

namespace hotel_booking_mvc.Controllers.Manager
{
    public class ManagerController : Controller
    {
        private readonly IHotelService _hotelService;
        private readonly IManagerService _managerService;

        public ManagerController(IHotelService hotelService, IManagerService managerService)
        {
            _hotelService = hotelService;
            _managerService = managerService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AllManagers()
        {
            return View();
        }

        public async Task<IActionResult> HotelAsync(string managerId)
        {
            managerId = "390e272d-a264-4d7b-b3af-8bdc2a1f92f3";
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
        public IActionResult HotelRooms()
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
    }
}
