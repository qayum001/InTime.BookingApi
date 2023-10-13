namespace InTime.Booking.Infrastructure.Services.AuthServices.DTOs
{
    public  class TokenHolder
    {
        public string AccessToken { get; private set; } = string.Empty;
        public string RefreshToken { get; private set; } = string.Empty;

        public TokenHolder(string accessToken, string refreshToken)
        {
            if (string.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException(nameof(accessToken));
            
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentNullException(nameof(refreshToken));

            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public TokenHolder()
        {

        }
    }
}
