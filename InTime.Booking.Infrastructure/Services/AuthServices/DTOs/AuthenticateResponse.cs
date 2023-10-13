using InTime.Booking.Infrastructure.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Booking.Infrastructure.Services.AuthServices.DTOs
{
    public class AuthenticateResponse : Response
    {
        public TokenHolder TokenHolder { get; private set; }

        public AuthenticateResponse(string status, string message, string accessToken, string refreshToken) : base(status, message)
        {
            TokenHolder = new TokenHolder(accessToken, refreshToken);
        }

        public AuthenticateResponse(string status, string message) : base(status, message)
        {
            TokenHolder = new TokenHolder();
        }
    }
}
