using hotel_booking_model.commons;
using hotel_booking_model.Dtos;
using hotel_booking_model.ViewModels;
using hotel_booking_services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class AdminService : IAdminService
    {
        private readonly IHttpRequestFactory _httpRequestFactory;
        public AdminService(IHttpRequestFactory httpRequestFactory)
        {
            _httpRequestFactory = httpRequestFactory;
        }

        public async Task<AdminStatisticsDto> GetAdminStatistics()
        {
            var response = await _httpRequestFactory.GetRequestAsync
                <BasicResponse<AdminStatisticsDto>>(
                    requestUrl: $"api/Statistics/get-statistics/admin",
                    baseUrl: "https://localhost:44319/");
            return response.Data;
        }
    }
}
