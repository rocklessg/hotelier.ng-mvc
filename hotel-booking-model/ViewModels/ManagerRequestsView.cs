using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model
{
    public class ManagerRequestsView
    {
        public string Email { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public bool ConfirmationFlag { get; set; }
    }
}
