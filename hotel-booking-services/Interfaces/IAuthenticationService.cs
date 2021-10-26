using hotel_booking_model.commons;
using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_model.ViewModels;
using System.Threading.Tasks;
using LoginViewModel = hotel_booking_model.Dtos.AuthenticationDtos.LoginViewModel;

namespace hotel_booking_services.Interfaces
{
    public interface IAuthenticationService
    {
        //Task<hotel_booking_model.LoginViewModel> Login(LoginDto loginDto);
        Task<BasicResponse<LoginViewModel>> Login(LoginDto loginDto);

        Task<RegisterDto> Register(RegisterDto registerdto);
        Task<string> ForgotPassword(string email);
        Task<string> UpdatePassword(UpdatePasswordDto updatePasswordDto);
    }
}
