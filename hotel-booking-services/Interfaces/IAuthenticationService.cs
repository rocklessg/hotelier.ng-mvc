using hotel_booking_model.commons;
using hotel_booking_model.Dtos.AuthenticationDtos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<BasicResponse<LoginViewModel>> Login(LoginDto loginDto);

        Task<RegisterDto> Register(RegisterDto registerdto);
    }
}
