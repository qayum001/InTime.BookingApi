using InTime.Booking.Domain.Common.Additional;
using InTime.Booking.Domain.Entity.User;
using InTime.Booking.Domain.Enum;

namespace InTime.Booking.Domain.Common
{
    public class BaseUser : BaseEntity
    {
        public string Email { get; private set; }
        public ICollection<string> Roles { get; protected set; } = new List<string>();
        public bool IsBookingUser => Roles.Contains(Role.BOOKING_USER.ToString());
        public AuthComponent AuthComponent { get; protected set; }
        public Guid AuthComponentId { get; protected set; }
        public BaseUser(Guid id, string name, string email, AuthComponent authComponent) : base(id, name)
        {
            Email = ValidEmail(email);
            AuthComponent = authComponent
                ?? throw new ArgumentNullException(nameof(authComponent), $"{AuthComponent} can not be null");

            AuthComponentId = authComponent.Id;
        }

        public Task<Response> AddRole(Role role)
        {
            var strRole = role.ToString();

            if (!Roles.Contains(strRole))
            {
                Roles.Add(strRole);
                return Task.FromResult(new Response(true, "Role Added"));
            }

            return Task.FromResult(new Response(false, "Role already exists"));
        }

        private string ValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(Email), "Email can not be null or empty");
            return email;
        }
    }
}