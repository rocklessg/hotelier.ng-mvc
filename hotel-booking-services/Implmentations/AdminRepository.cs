using hotel_booking_services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IHttpRequestFactory _httpRequestFactory;
        public AdminRepository(IHttpRequestFactory httpRequestFactory)
        {
            _httpRequestFactory = httpRequestFactory;
        }

        public async Task<IEnumerable<>> GetAllTransactionsAsync(int pageNumber)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _requestFactory.GetRequestAsync
                <BasicResponse<IEnumerable<>>>(
                    requestUrl: $"api/admin/all-hotels?PageSize=3&PageNumber={pageNumber}",
                    baseUrl: "http://hoteldotnet.herokuapp.com");
            return response.Data;
        }

    }
}
