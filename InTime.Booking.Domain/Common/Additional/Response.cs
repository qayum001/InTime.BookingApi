namespace InTime.Booking.Domain.Common.Additional
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public Response(bool status, string message) 
        {
            IsSuccess = status;
            Message = message;
        }

        public Response() { }
    }
}