using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_model.ViewModels;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginViewModel> Login(LoginDto loginDto);
        Task<RegisterDto> Register(RegisterDto registerdto);
    }
}
