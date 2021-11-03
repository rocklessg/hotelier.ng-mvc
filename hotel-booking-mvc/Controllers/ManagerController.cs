using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_mvc.CustomAuthorization;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using hotel_booking_model;
using hotel_booking_model.ViewModels;
using System.Collections.Generic;
using System.Net.Http;

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
        public IActionResult Account()
        {
            var loggedInUser = HttpContext.Session.GetString("User");

            var user = JsonConvert.DeserializeObject<ManagerModel>(loggedInUser);
            var manager = _managerService.GetManagerById(user.ManagerId);
            ViewData["FirstName"] = user.FirstName;
            ViewData["Manager"] = manager;

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Account(UserDto userDto)
        {
            //var loggedInUser = HttpContext.Session.GetString("User");
            //var user = JsonConvert.DeserializeObject<UserDto>(loggedInUser);
            //userDto.Id = user.Id;

            if (ModelState.IsValid)
            {
                var response = await _managerService.EditManagerAccountAsync(userDto);

                return View();
            }
            throw new ArgumentException("user data can not be null");
        }
       

        public async Task<IActionResult> UpdateManagerDetails(string managerId)
        {
            var result = await _managerService.GetManagerById(managerId);
            return View(result);
        }
        //[HttpGet]
      /*  public async Task<IActionResult> UpdateManagerDetails()
        {
            IEnumerable<EditManagerViewModel> EditManager = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new baseUrl("");
                var responseTask = client.GetAsync("Manaager");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EditManagerViewModel>>();
                    readTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<EditManagerViewModel>>();
                        readTask.Wait();
                        EditManager = readTask.Result;
                    }
                    else
                    {
                        EditManager = TaskAsyncEnumerableExtensions.Empty<EditManagerViewModel>();
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                return View(EditManager);
            }*/

        //}
    }
}
