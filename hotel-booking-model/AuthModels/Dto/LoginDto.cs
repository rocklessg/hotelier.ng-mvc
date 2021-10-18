using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.AuthModels.Dto
{
    public class LoginDto
    {
        public string[] Data { get; set; }
        public string Succeeded { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
    }
}
