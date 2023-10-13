namespace InTime.Booking.Infrastructure.Services.AuthServices.DTOs
{
    public class LoginCredentials
    {
        public string Email { get; }
        public string Password { get; }

        public LoginCredentials(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            Email = email;
            Password = password;
        }
    }
}