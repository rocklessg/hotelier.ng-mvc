using hotel_booking_model.commons;
using hotel_booking_model.Dtos.AuthenticationDtos;
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
                result.Data.Claim = decodedValue.Claims.ElementAt(1);
                return result;
            }

            return result;
        }

    
        public async Task<RegisterDto> Register(RegisterDto registerdto)
        {
            var result = await _httpRequestFactory.PostRequestAsync<RegisterDto, BasicResponse<RegisterDto>>("/api/Authentiation/register", registerdto);
            return result.Data;
        }
        

    }
}
