using hotel_booking_model;
using hotel_booking_model.AuthModels;
using hotel_booking_model.AuthModels.Dto;
using hotel_booking_services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Implmentations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IHttpRequestFactory _httpRequestFactory;
        public AuthRepository(IHttpRequestFactory httpRequestFactory)
        {
            _httpRequestFactory = httpRequestFactory;
        }

        public LoginDto Login(LoginModel loginModel)
        {

            var response = _httpRequestFactory.PostRequestAsync<LoginModel, LoginDto>("/api/Authentication/login", loginModel);
            LoginDto login = response.Result;
            return login;
 }


        public SignupDto Signup(SignupModel signupModel) 

        {
            var response = _httpRequestFactory.PostRequestAsync<SignupModel, SignupDto>("/api/Authentication", signupModel);
            SignupDto signup = response.Result;
            return signup;
        }
    }
}
