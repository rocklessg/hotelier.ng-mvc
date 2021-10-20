using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model.Dtos.AuthenticationDtos
{
    public class LoginResponseDto
    {
        public string Id { get; set; }
        public string Token { get; set; }
    }
}
