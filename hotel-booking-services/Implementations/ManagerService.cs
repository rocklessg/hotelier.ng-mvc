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

        private IEnumerable<CustomerViewModel> GetTopCustomersForManger(string managerId)
        {
            return new List<CustomerViewModel>();
        }

        public async Task<ManagerDashboardViewModel> ShowManagerDashboard(string managerId)
        {
            var statistics = await GetManagerStatistics(managerId);
            var topCustomers = GetTopCustomersForManger(managerId);
            var result = new ManagerDashboardViewModel(statistics, topCustomers);
            return result;
        }
    }
}
