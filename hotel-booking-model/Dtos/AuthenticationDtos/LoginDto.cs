using System.ComponentModel.DataAnnotations;

namespace hotel_booking_model.Dtos.AuthenticationDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Enter Email To Continue")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password To Continue")]
        public string Password { get; set; }
    }
}
