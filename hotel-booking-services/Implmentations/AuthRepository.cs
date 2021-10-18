<<<<<<< HEAD
﻿using hotel_booking_model;
using hotel_booking_model.AuthModels;
=======
﻿using hotel_booking_model.AuthModels;
>>>>>>> reviews
using hotel_booking_model.AuthModels.Dto;
using hotel_booking_services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Net.Http;
=======
>>>>>>> reviews
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
<<<<<<< HEAD
           
=======

>>>>>>> reviews
        }



<<<<<<< HEAD
        public SignupDto Signup(SignupModel signupModel) 
=======
        public SignupDto Signup(SignupModel signupModel)
>>>>>>> reviews
        {
            var response = _httpRequestFactory.PostRequestAsync<SignupModel, SignupDto>("/api/Authentication", signupModel);
            SignupDto signup = response.Result;
            return signup;
        }
    }
}
<<<<<<< HEAD
=======

>>>>>>> reviews
