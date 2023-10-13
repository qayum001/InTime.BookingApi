using InTime.Booking.Domain.Common;

namespace InTime.Booking.Domain.Entity.User
{
    public class Admin : BaseUser
    {
        public Admin(Guid id, string name, string email, AuthComponent authComponent) : base(id, name, email, authComponent)
        {
            this.AddRole(Enum.Role.ADMIN);
        }
    }
}
