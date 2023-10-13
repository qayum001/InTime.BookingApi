using InTime.Booking.Infrastructure.Common.Response;
using InTime.Booking.Infrastructure.Services.AuthServices.DTOs;
using InTime.Booking.Infrastructure.Services.TokenServices.DTOs;

namespace InTime.Booking.Infrastructure.Services.AuthServices
{
    public interface IAuthService
    {
        Task<Response> Register(RegisterDto registerDto);
        Task<AuthenticateResponse> Login(LoginCredentials loginCredentials);
        Task<Response> Logout(string token);
        Task<TokenResponse> Refresh(string accessToken, string refreshToken);
    }
}