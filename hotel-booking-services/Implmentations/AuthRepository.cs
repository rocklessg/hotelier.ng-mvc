using hotel_booking_model;
using hotel_booking_model.AuthModels;
using hotel_booking_model.AuthModels.Dto;
using hotel_booking_model.commons;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;

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

        public async Task<string> ForgotPassword(string email) 
        {

           
            string url = $"api/Authentication/forgot-password?email={email}";
            var response = await _httpRequestFactory.PostRequestAsync<string, BasicResponse<string>>(url, string.Empty);
           
             return response.Message;
        }

        public async Task<string> UpdatePassword(UpdatePasswordDto updatePasswordDto) 
        {
            string url = $"api/Authentication/update-password";
            var response = await _httpRequestFactory.PostRequestAsync<UpdatePasswordDto, BasicResponse<string>>(url, updatePasswordDto);

            return response.Message;

        }

    }
}
