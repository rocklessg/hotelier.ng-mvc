using hotel_booking_model.commons;
using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_model.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginViewModel> Login(LoginDto loginDto);

       // public SignupDto Signup(SignupModel signupModel);

        Task<RegisterDto> Register(RegisterDto registerdto);
    }
}
