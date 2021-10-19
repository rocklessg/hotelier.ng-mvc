using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalManagers { get; set; }
        public int TotalHotels { get; set; }
        public decimal TotalMonthlyCommission { get; set; }
        public List<HotelBasicView> TopHotels { get; set; }
    }
}
