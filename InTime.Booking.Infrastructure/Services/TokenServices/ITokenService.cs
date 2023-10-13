using InTime.Booking.Domain.Common;
using InTime.Booking.Infrastructure.Services.TokenServices.DTOs;

namespace InTime.Booking.Infrastructure.Services.TokenServices
{
    public interface ITokenService
    {
        Task<TokenResponse> GenerateAccessToken(BaseUser user);
        Task<TokenResponse> Refresh(BaseUser user, string refreshToken);
        Task<Guid> GetUserIdByToken(string token);
    }
}