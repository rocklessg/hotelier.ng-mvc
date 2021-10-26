using hotel_booking_model.Dtos.TransactionsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<TransactionsResponseDto>> GetAllTransactions(int pageSize = 10, int pageNumber = 1);
    }
}
