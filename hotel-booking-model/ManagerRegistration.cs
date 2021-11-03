
using hotel_booking_model.Dtos;

namespace hotel_booking_model
{
    public class ManagerRegistration
    {
        //Manager Details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public int Age { get; set; }

        //Company Details
        public string CompanyName { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessPhone { get; set; }
        public string CompanyAddress { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }

        // Hotel Details
        public string HotelName { get; set; }
        public string HotelDescription { get; set; }
        public string HotelAddress { get; set; }
        public string HotelCity { get; set; }
        public string HotelState { get; set; }
        public string HotelEmail { get; set; }
        public string HotelPhone { get; set; }

        public string Token { get; set; }

        public RegisterManagerMailToken ManagerMailToken { get; set; }
    }
}
