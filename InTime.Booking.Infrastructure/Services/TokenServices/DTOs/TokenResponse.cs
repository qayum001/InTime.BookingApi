using InTime.Booking.Application.Common.Response;

namespace InTime.Booking.Infrastructure.Services.TokenServices.DTOs
{
    public class TokenResponse : Response
    {
        public string AccessToken { get; private set; } = string.Empty;
        public string RefreshToken { get; private set; } = string.Empty;
        public DateTime RefreshTokenExpiriesDate { get; private set; }

        public TokenResponse(string status, string message, string accessToken, string refreshToken, int lifeTime) : base(status, message)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken), $"{nameof(accessToken)} can not be empty");
            AccessToken = accessToken;

            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentNullException(nameof(refreshToken), $"{nameof(refreshToken)} can not be empty");
            RefreshToken = refreshToken;

            RefreshTokenExpiriesDate = DateTime.Now.AddDays(lifeTime); ;
        }

        public TokenResponse(string status, string message) : base(status, message)
        {

        }
    }
}