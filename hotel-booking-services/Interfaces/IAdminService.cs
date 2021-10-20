using hotel_booking_model.Dtos;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IAdminService
    {
        Task<AdminStatisticsDto> GetAdminStatistics();
    }
}
