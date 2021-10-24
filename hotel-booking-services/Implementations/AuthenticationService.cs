using hotel_booking_model.commons;
using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpRequestFactory _httpRequestFactory;
        
        public AuthenticationService(IHttpRequestFactory httpRequestFactory)
        {
            _httpRequestFactory = httpRequestFactory;
            
        }

        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {

            var result = await _httpRequestFactory.PostRequestAsync<LoginDto, BasicResponse<LoginResponseDto>>("/api/Authentication/login", loginDto) ;
            return result.Data;
        }


        public async Task<RegisterDto> Register(RegisterDto registerdto)
        {
            var result = await _httpRequestFactory.PostRequestAsync<RegisterDto, BasicResponse<RegisterDto>>("/api/Authentiation/register", registerdto);
            return result.Data;
        }
        

    }
}
