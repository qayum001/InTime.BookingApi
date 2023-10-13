namespace InTime.Booking.Infrastructure.Services.AuthServices.DTOs
{
    public class RegisterDto
    {
        public 
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Guid FacultyId { get; private set; }
        public Guid GroupId { get; private set; }
    }
}