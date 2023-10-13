using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Infrastructure.Common.Response;
using InTime.Booking.Infrastructure.Services.AuthServices.DTOs;
using InTime.Booking.Infrastructure.Services.TokenServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Booking.Infrastructure.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<AuthenticateResponse> Login(LoginCredentials loginCredentials)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Logout(string token)
        {
            throw new NotImplementedException();
        }

        public Task<TokenResponse> Refresh(string accessToken, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Register(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }
    }
}
