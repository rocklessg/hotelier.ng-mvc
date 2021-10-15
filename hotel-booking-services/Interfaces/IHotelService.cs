using hotel_booking_model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
	public interface IHotelService
	{
		Task<IEnumerable<HotelBasicView>> GetAllHotelAsync(int pageNumber);
        Task<IEnumerable<HotelBasicView>> GetAllHotelForManagerAsync(string managerId);
    }
}
