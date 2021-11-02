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


        public async Task<PaginationResponse<IEnumerable<ManagerTransactionsView>>> GetAllManagerTransactionsAsync(string managerId, int pageSize = 10, int pageNumber = 1, string searchQuery = null)
        {

            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<PaginationResponse<IEnumerable<ManagerTransactionsView>>>>
                                                    (requestUrl: $"/api/Admin/{managerId}/transaction?PageSize={pageSize}&PageNumber={pageNumber}&SearchQuery={searchQuery}",
                                                      baseUrl: "http://hoteldotnet.herokuapp.com");

            return response.Data;
        }


        public async Task<PaginationResponse<IEnumerable<ManagerModel>>> GetAllManagersAsync(int? pageNumber)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<PaginationResponse<IEnumerable<ManagerModel>>>>
                                                    (requestUrl: $"/api/Manager/HotelManagers?PageSize=5&PageNumber={pageNumber}");

            return response.Data;
        }


    }
}
