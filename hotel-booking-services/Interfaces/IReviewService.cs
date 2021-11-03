using hotel_booking_model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewsDto> GetHotelReviews(string id);
   
    }
}
