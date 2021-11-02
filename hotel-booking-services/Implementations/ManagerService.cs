using hotel_booking_model;
using hotel_booking_model.commons;
using hotel_booking_model.Dtos;
using hotel_booking_model.ViewModels;
using hotel_booking_services.Interfaces;
using System;
using System.Collections.Generic;
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


        public async Task<ManagerStatisticDto> GetManagerStatistics(string managerId)
        {
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<ManagerStatisticDto>>(
                requestUrl: $"api/Statistics/{managerId}/hotelManager");

            return response.Data;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetTopCustomersForMangerAsync(string managerId)
        {
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<IEnumerable<CustomerViewModel>>>(
                requestUrl: $"api/Manager/{managerId}/top-customers");

            return response.Data;
        }

        public async Task<ManagerDashboardViewModel> ShowManagerDashboard(string managerId)
        {
            var statistics = await GetManagerStatistics(managerId);

            var topCustomers = await GetTopCustomersForMangerAsync(managerId);

            var result = new ManagerDashboardViewModel(statistics, topCustomers);

            return result;

        }

        public async Task<PaginationResponse<IEnumerable<ManagerModel>>> GetAllManagersAsync( int? pageNumber)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<PaginationResponse<IEnumerable<ManagerModel>>>>
                                                    (requestUrl: $"/api/Manager/HotelManagers?PageSize=5&PageNumber={pageNumber}");

            return response.Data;
        }


        public async Task<PaginationResponse<IEnumerable<ManagerRequests>>> GetAllManagerRequests(int? pageNumber)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<PaginationResponse<IEnumerable<ManagerRequests>>>>(
                                                       requestUrl: $"/api/Manager/getall-request?PageSize=10&PageNumber={pageNumber}");
            return response.Data;
        }


        public async Task<bool>SendManagerInvite(string email)
        {
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<bool>>(
                                requestUrl: $"/api/Manager/send-invite?email={email}");
            return response.Succeeded;
        }

    }
}
