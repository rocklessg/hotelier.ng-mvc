using hotel_booking_model;
using hotel_booking_model.commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
	public interface IHotelService
	{
		Task<PaginationResponse<IEnumerable<HotelBasicView>>> GetAllHotelAsync(int pageNumber);
        Task<PaginationResponse<IEnumerable<HotelBasicView>>> GetAllHotelForManagerAsync(string managerId);
    }
}
