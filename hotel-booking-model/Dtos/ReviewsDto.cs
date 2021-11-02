using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.Dtos
{
    public class ReviewsDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string CustomerId { get; set; }
        public string HotelId { get; set; }
        public string CreatedAt { get; set; }
        public int PageSie { get; set; }
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int PreviosPage { get; set; }
    }
}
