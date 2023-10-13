using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Booking.Application.Common.Response
{
    public class Response
    {
        public string Status { get; private set; }
        public string Message { get; private set; }

        public Response(string status, string message)
        {
            if (string.IsNullOrEmpty(status))
                throw new ArgumentNullException(nameof(status), $"{nameof(status)} can not be empty");
            Status = status;
            Message = message;
        }
    }
}
