﻿using hotel_booking_model;
using hotel_booking_model.commons;
using hotel_booking_model.Dtos.Hotels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
	public interface IHotelService
	{
		Task<PaginationResponse<IEnumerable<HotelBasicView>>> GetAllHotelAsync(int pageNumber);
        Task<IEnumerable<HotelBasicView>> GetAllHotelForManagerAsync(string managerId);
		Task<IEnumerable<HotelBasicDetailsDto>> GetTopHotelsAsync();
		Task<Dictionary<string, int>> GetTotalHotelsPerLocation();
		Task<HotelDetailsViewDTo> GetHotelById(string hotelId);
	}
}