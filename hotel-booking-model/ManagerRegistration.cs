
using DataAnnotationsExtensions;
using hotel_booking_model.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace hotel_booking_model
{
    public class ManagerRegistration
    {
        //Manager Details
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[!*@#$%^&+=]).*$",
            ErrorMessage = "Password should contain upper, lower, figure and special character with a min length of 8.")]
        public string Password { get; set; }

        [RegularExpression(@"^[0]\d{10}$",
            ErrorMessage = "Phone Number should begin with 0 and have a lenght of 11 figures")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^(?:male|Male|female|Female)$",
            ErrorMessage = "Gender can only contain alphabeths and must be male or female")]
        public string Gender { get; set; }
        public string State { get; set; }
        [Min(18)]
        public int Age { get; set; }

        //Company Details
        public string CompanyName { get; set; }
        public string BusinessEmail { get; set; }

        [RegularExpression(@"^[0]\d{10}$",
           ErrorMessage = "Phone Number should begin with 0 and have a lenght of 11 figures")]
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
    }
}
