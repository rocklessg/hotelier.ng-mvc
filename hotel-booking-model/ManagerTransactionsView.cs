using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model
{
    public class ManagerTransactionsView
    {
        public string Name { get; set; }
        public string ServiceName { get; set; }
        public string BookingReference { get; set; }
        public bool Status { get; set; }
        public double Amount { get; set; }
        public double Commission { get; set; } 
       
    }
}
