using hotel_booking_model.Dtos;
using hotel_booking_model.ViewModels;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminDashboardViewModel> ShowAdminDashboard();
        Task<AdminStatisticsDto> GetAdminStatistics();
    }
}
