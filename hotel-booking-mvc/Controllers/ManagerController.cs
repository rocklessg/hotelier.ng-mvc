﻿using hotel_booking_model;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers.Manager
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IHotelService _hotelService;

        public ManagerController(IManagerService managerService,IHotelService hotelService)
        {
            _managerService = managerService;
            _hotelService = hotelService;
        }

        public async Task<IActionResult> DashboardAsync(string managerId)
        {
            var result = await _managerService.ShowManagerDashboard(managerId);
            return View(result);
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

        public IActionResult Transactions()
        {
            return View();
        }
        public IActionResult HotelRooms()
        {
            return View();
        }

        public IActionResult HotelDetails(string hotelId)
        {
            return View();
        }
    }
}
