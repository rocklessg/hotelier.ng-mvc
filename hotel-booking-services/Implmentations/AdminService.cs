using hotel_booking_model.commons;
using hotel_booking_model.Dtos.TransactionsDtos;
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
        private readonly IHttpRequestFactory _requestFactory;


        public AdminService(IHttpRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
        }
        public async Task<IEnumerable<TransactionsResponseDto>> GetAllTransactions(int pageSize = 10, int pageNumber = 1)
        {
            var result = await _requestFactory.GetRequestAsync<BasicResponse<IEnumerable<TransactionsResponseDto>>>
                (
                $"api/Admin/transaction?PageSize={pageSize}&PageNumber={pageNumber}",
                "http://hoteldotnet.herokuapp.com"
                );
            return result.Data;
        }
    }
}
