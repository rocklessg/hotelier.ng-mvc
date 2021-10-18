using hotel_booking_model.AuthModels;
using hotel_booking_model.AuthModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_services.Interfaces
{
    public interface IAuthRepository
    {
        public LoginDto Login(LoginModel loginModel);

        public SignupDto Signup(SignupModel signupModel);
    }
}
