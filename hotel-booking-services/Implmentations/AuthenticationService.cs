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
        private readonly IHttpContextAccessor _httpContext;
        
        public AuthenticationService(IHttpRequestFactory httpRequestFactory, IHttpContextAccessor httpContext)
        {
            _httpRequestFactory = httpRequestFactory;
           _httpContext = httpContext;


        }

        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {

            var result = await _httpRequestFactory.PostRequestAsync<LoginDto, BasicResponse<LoginResponseDto>>("/api/Authentication/login", loginDto);
            return result.Data;
        }


        public async Task<RegisterDto> Register(RegisterDto registerdto)
        {
            var result = await _httpRequestFactory.PostRequestAsync<RegisterDto, BasicResponse<RegisterDto>>("/api/Authentiation/register", registerdto);
            return result.Data;
        }

        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<string> ForgotPassword(string email)
        {


            string url = $"api/Authentication/forgot-password?email={email}";
            var response = await _httpRequestFactory.PostRequestAsync<string, BasicResponse<string>>(url, string.Empty);

            return response.Message;
        }

        /// <summary>
        /// UpdatePassword
        /// </summary>
        /// <param name="updatePasswordDto"></param>
        /// <returns></returns>
        public async Task<string> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            string url = $"api/Authentication/update-password";
            var response = await _httpRequestFactory.UpdateRequestAsync<UpdatePasswordDto, BasicResponse<string>>(url, updatePasswordDto);

            return response.Message;

        }


    }
}
