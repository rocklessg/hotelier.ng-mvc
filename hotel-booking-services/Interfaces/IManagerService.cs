using hotel_booking_model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IManagerService
    {
        Task<ManagerDashboardViewModel> ShowManagerDashboard(string managerId);
    }
}
