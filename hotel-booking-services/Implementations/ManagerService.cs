using hotel_booking_model;
using hotel_booking_model.commons;
using hotel_booking_services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class ManagerService : IManagerService
    {
        private readonly IHttpRequestFactory _httpRequestFactory;
        public ManagerService(IHttpRequestFactory httpRequestFactory)
        {
            _httpRequestFactory = httpRequestFactory;
        }

        public async Task<PaginationResponse<IEnumerable<ManagerTransactionsView>>> GetAllManagerTransactionsAsync(string managerId, int pageNumber)
        {

            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<PaginationResponse<IEnumerable<ManagerTransactionsView>>>>
            (requestUrl: $"/api/Admin/{managerId}/transaction?PageSize=5&PageNumber={pageNumber}",
            baseUrl: "https://localhost:44379");

            return response.Data;
        }

    }
}
