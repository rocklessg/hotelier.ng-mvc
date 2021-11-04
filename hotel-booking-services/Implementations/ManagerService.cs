using hotel_booking_model;
using hotel_booking_model.commons;
using hotel_booking_model.Dtos;
using hotel_booking_model.Dtos.AuthenticationDtos;
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

        public async Task<PaginationResponse<IEnumerable<ManagerTransactionsView>>> GetAllManagerTransactionsAsync(string managerId, int pageSize = 10, int pageNumber = 1, string searchQuery = null)
        {

            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<PaginationResponse<IEnumerable<ManagerTransactionsView>>>>
                                                    (requestUrl: $"/api/Admin/{managerId}/transaction?PageSize={pageSize}&PageNumber={pageNumber}&SearchQuery={searchQuery}");

            return response.Data;
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

        public async Task<PaginationResponse<IEnumerable<ManagerModel>>> GetAllManagersAsync(int? pageNumber)

        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<PaginationResponse<IEnumerable<ManagerModel>>>>
                                                    (requestUrl: $"/api/Manager/HotelManagers?PageSize=5&PageNumber={pageNumber}");

            return response.Data;
        }

        public async Task<PaginationResponse<IEnumerable<ManagerRequestsView>>> GetAllManagerRequests(int? pageNumber)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<PaginationResponse<IEnumerable<ManagerRequestsView>>>>(
                                                       requestUrl: $"/api/Manager/getall-request?PageSize=10&PageNumber={pageNumber}");
            return response.Data;
        }


        public async Task<bool> SendManagerInvite(string email)
        {
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<bool>>(
                                requestUrl: $"/api/Manager/send-invite?email={email}");
            return response.Succeeded;
        }

        public async Task<string> EditManagerAccountAsync(EditManagerViewModel model)
        {
            var response = await _httpRequestFactory.UpdateRequestPutAsync<EditManagerViewModel, BasicResponse<string>>
                                                    (requestUrl: $"/api/Manager/UpdateManager", model);

            return response.Message;
        }


        public async Task<bool> RegisterManager(ManagerRegistration managerRegistration)
        {
            var response = await _httpRequestFactory.PostRequestAsync<ManagerRegistration, BasicResponse<bool>>(
                                requestUrl: "/api/Manager/AddManager", content: managerRegistration);
            return response.Succeeded;
        }

        public async Task<EditManagerViewModel> GetManagerById(string managerId)
        {
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<EditManagerViewModel>>
                (requestUrl: $"/api/Manager/Details");
            return response.Data;
        }
        public async Task<PaginationResponse<IEnumerable<ManagerBookingDto>>> GetManagerBookingAsync(string managerId, int pageNumber = 1, int pageSize = 10)
        {
            var response = await _httpRequestFactory.GetRequestAsync<BasicResponse<PaginationResponse<IEnumerable<ManagerBookingDto>>>>
                ($"api/Manager/{managerId}/bookings?PageSize={pageSize}&PageNumber={pageNumber}");
            return response.Data;
        }        

    }
}
