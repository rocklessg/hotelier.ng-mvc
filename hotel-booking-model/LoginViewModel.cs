using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model
{
    public class LoginViewModel
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public Claim Claim { get; set; }
    }
}
