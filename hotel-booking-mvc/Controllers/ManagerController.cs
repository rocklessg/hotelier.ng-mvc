
﻿using hotel_booking_model;
using hotel_booking_model.ViewModels;
using hotel_booking_mvc.CustomAuthorization;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using hotel_booking_model.Dtos.AuthenticationDtos;
using Newtonsoft.Json;


using Microsoft.AspNetCore.Authorization;
using System;

namespace hotel_booking_mvc.Controllers.Manager
{
    //[CustomAuthenticationFilter(roles: new string[] { "Manager" })]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IHotelService _hotelService;
        private readonly IAuthenticationService _managerAuth;



        public ManagerController(IHotelService hotelService, IManagerService managerService,IAuthenticationService managerAuth)

        {
            _managerAuth = managerAuth;
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

        public IActionResult Account()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Account(UserDto userDto)
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult RegisterManager()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(UpdatePasswordDto obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var response = _managerAuth.UpdatePassword(obj);
                ViewBag.Data = response.Result;
                return View();
            }
            catch (Exception)
            {
                TempData["error"] = "Oops something bad happened try again!";
                return View();
            }
        }
    }
}
