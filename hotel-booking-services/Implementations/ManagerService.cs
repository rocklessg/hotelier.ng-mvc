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

        public async Task<IEnumerable<ManagerTransactionsView>> GetAllManagerTransactionsAsync(string managerId)
        {
            var response = await _httpRequestFactory.GetRequestAsync
                <BasicResponse<IEnumerable<ManagerTransactionsView>>>(
                    requestUrl: $"api/Manager/{managerId}/hotels", // change this line to connect to the right api endpoint
                    baseUrl: "http://hoteldotnet.herokuapp.com");
            return response.Data;
        }

    }
}
