using InTime.Booking.Domain.Common.Additional;
using InTime.Booking.Domain.Enum;
using System.Xml.Linq;

namespace InTime.Booking.Domain.Common
{
    public class BaseUser : BaseEntity
    {
        public string Email { get; }
        public List<Role> Roles { get; protected set; } = new List<Role>();
        public bool IsBookingUser => Roles.Contains(Role.BOOKING_USER);
        public BaseUser(Guid id, string name, string email) : base(id, name)
        {
            Email = ValidEmail(email);
        }

        public Task<Response> AddRole(Role role)
        {
            if (!Roles.Contains(role))
            {
                Roles.Add(role);
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