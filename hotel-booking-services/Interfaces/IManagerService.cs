using hotel_booking_model;
using hotel_booking_model.commons;
using hotel_booking_model.Dtos;
using hotel_booking_model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IManagerService
    {
        public Task<PaginationResponse<IEnumerable<ManagerTransactionsView>>> GetAllManagerTransactionsAsync(string managerId, int pageSize = 10, int pageNumber = 1, string searchQuery = null);
        public  Task<PaginationResponse<IEnumerable<ManagerModel>>> GetAllManagersAsync(int? pageNumber);
        Task<ManagerDashboardViewModel> ShowManagerDashboard(string managerId);
        Task<PaginationResponse<IEnumerable<ManagerBookingDto>>> GetManagerBookingAsync(string managerId, int pageNumber = 1, int pageSize = 10);
    }
}
