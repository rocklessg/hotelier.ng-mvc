using hotel_booking_model;
using hotel_booking_model.commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IManagerService
    {
        Task<PaginationResponse<IEnumerable<ManagerModel>>> GetAllManagersAsync(int? pageNumber);
    }
}
