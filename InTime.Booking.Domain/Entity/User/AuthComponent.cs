using InTime.Booking.Domain.Common;

namespace InTime.Booking.Domain.Entity.User
{
    public class AuthComponent : BaseEntity
    {
        public BaseUser User { get; private set; }
        public Guid UserId { get; private set; }
        public string Login { get; private set; }
        public string Passowrd { get; private set; }

        //
        public string RefreshToken { get; private set; } = string.Empty;
        public DateTime ExpiriesDate { get; private set; }

        public AuthComponent(Guid id, string name, BaseUser user, string login, string passowrd) : base(id, name)
        {
            Login = login;
            Passowrd = passowrd;
            User = user;
            UserId = user.Id;
        }

        public Task Refresh(string refreshToken, DateTime expiriesDate)
        {
            if (string.IsNullOrEmpty(RefreshToken))
                throw new ArgumentException($"{nameof(RefreshToken)} can not be empty", nameof(RefreshToken));

            RefreshToken = refreshToken;
            ExpiriesDate = expiriesDate;
            return Task.CompletedTask;
        }

        public Task ChangeLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentException("passowrd can not be empty", nameof(login));
            }

            Login = login;

            return Task.CompletedTask;
        }

        public Task ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("passowrd can not be empty", nameof(password));
            }

            Passowrd = password;

            return Task.CompletedTask;
        }
    }
}
