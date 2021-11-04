using hotel_booking_model.commons;
using hotel_booking_model.Dtos.AuthenticationDtos;
using hotel_booking_model.ViewModels;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public async Task<BasicResponse<LoginViewModel>> Login(LoginDto loginDto)
        {
            var handler = new JwtSecurityTokenHandler();



            var result = await _httpRequestFactory.PostRequestAsync<LoginDto, BasicResponse<LoginViewModel>>("/api/Authentication/login", loginDto);
            if (result.Succeeded)
            {
                _httpContextAccessor.HttpContext.Session.SetString("access_token", result.Data.Token);
                _httpContextAccessor.HttpContext.Session.SetString("user", JsonConvert.SerializeObject(result));
                JwtSecurityToken decodedValue = handler.ReadJwtToken(result.Data.Token);

                result.Data.Claims = decodedValue.Claims;

                return result;
            }
            return result;
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
            string url = $"api/Authentication/change-password";
            var response = await _httpRequestFactory.UpdateRequestAsync<UpdatePasswordDto, BasicResponse<string>>(url, updatePasswordDto);
            return response.Message;
        }


        public async Task<bool> SendManagerRequest(ManagerRequest managerRequest)
        {
           var response = await _httpRequestFactory.PostRequestAsync<ManagerRequest, 
               BasicResponse<ManagerRequest>>("/api/Manager/request", managerRequest);
            return response.Succeeded;
        }
    }
}
