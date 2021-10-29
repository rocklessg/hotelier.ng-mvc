using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model
{
    public class ManagerTransactionsView
    {
        public string BookingId { get; set; }
        public string BookingReference { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime checkOut { get; set; }
        public double ServiceName { get; set; }
        public double PayementAmount { get; set; }
        public double PayementMethod { get; set; }
        public double Commission { get; set; }
        public double HotelId { get; set; }
        public double HotelName { get; set; }
        public double CustomerName { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedAt { get; set; }

        /*"bookingId": "a6322605-fa87-4859-86e7-027e2368f16b",
        "bookingReference": "3f38ba94-0c9a-46d0-8648-80a28df89808",
        "checkIn": "2021-02-21T00:00:00",
        "checkOut": "2021-02-04T00:00:00",
        "serviceName": "19",
        "paymentAmount": 80000,
        "paymentStatus": "False",
        "paymentMethod": "Online Payment",
        "commission": 8000,
        "hotelId": "b5a33001-2b43-467f-b01a-0d3097f891bb",
        "hotelName": "Shoreline Hotel",
        "customerName": null,
        "paymentDate": "0001-01-01T00:00:00",
        "createdAt": "2021-10-26T21:08:39.09273"*/

    }
}
