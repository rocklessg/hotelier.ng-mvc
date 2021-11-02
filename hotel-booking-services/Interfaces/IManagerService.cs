using hotel_booking_model;
using hotel_booking_model.commons;
using hotel_booking_model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IManagerService
    {
        Task<ManagerDashboardViewModel> ShowManagerDashboard(string managerId);

        Task<PaginationResponse<IEnumerable<ManagerModel>>> GetAllManagersAsync(int? pageNumber);

        Task<PaginationResponse<IEnumerable<ManagerRequests>>> GetAllManagerRequests(int? pageNumber);

        Task<bool> SendManagerInvite(string email);

    }
}
