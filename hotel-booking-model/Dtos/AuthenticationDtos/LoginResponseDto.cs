using System.Security.Claims;

namespace hotel_booking_model.Dtos.AuthenticationDtos
{
    public class LoginViewModel
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public Claim  Claim { get; set; }
       

    }
}
