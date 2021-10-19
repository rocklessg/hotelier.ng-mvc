using hotel_booking_services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly IHttpRequestFactory _httpRequestFactory;
        public ManagerRepository(IHttpRequestFactory httpRequestFactory)
        {
            _httpRequestFactory = httpRequestFactory;
        }

    }
}
