using hotel_booking_model.commons;
using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_model.ViewModels;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpRequestFactory _httpRequestFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IHttpRequestFactory httpRequestFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpRequestFactory = httpRequestFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginViewModel> Login(LoginDto loginDto)
        {

            var result = await _httpRequestFactory.PostRequestAsync<LoginDto, BasicResponse<LoginViewModel>>("/api/Authentication/login", loginDto);
            _httpContextAccessor.HttpContext.Session.SetString("access_token", result.Data.Token);
            return result.Data;
        }


        public async Task<RegisterDto> Register(RegisterDto registerdto)
        {
            var result = await _httpRequestFactory.PostRequestAsync<RegisterDto, BasicResponse<RegisterDto>>("/api/Authentiation/register", registerdto);
            return result.Data;
        }
    }
}
