using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.University;

namespace InTime.Booking.Domain.Entity.User
{
    public class Teacher : BaseUser
    {
        public ICollection<Faculty> Faculties { get; } = new List<Faculty>();
        public Teacher(Guid id,
            string name,
            string email, AuthComponent authComponent) : base(id, name, email, authComponent)
        {
            this.AddRole(Enum.Role.STAFF);
        }
    }
}