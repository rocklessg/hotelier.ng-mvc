using hotel_booking_model.Dtos;
using hotel_booking_services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hotel_booking_services.Implementations
{
    public class ReviewService : IReviewService
    {

        private readonly IHttpRequestFactory _httpRequestFactory;

        public ReviewService(IHttpRequestFactory httpRequestFactory)
        {
            _httpRequestFactory = httpRequestFactory;
        }
        public async Task<ReviewsDto> GetHotelReviews(string hotelId)
        {
            
            var result = await _httpRequestFactory.GetRequestAsync<ReviewsDto>($"/api/Hotel/{hotelId}/reviews");
            
            return result;
        }
    }
}
