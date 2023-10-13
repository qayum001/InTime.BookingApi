using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.University;

namespace InTime.Booking.Domain.Entity.User
{
    public class Staff : BaseUser
    {
        public Faculty Faculty { get; }
        public Guid FacultyId { get; }
        public Staff(Guid id,
            string name,
            string email,
            Faculty faculty, AuthComponent authComponent) : base(id, name, email, authComponent)
        {
            Faculty = faculty
                ?? throw new ArgumentNullException(nameof(Faculty), "Faculty can not be null");

            FacultyId = faculty.Id;

            this.AddRole(Enum.Role.STAFF);
        }
    }
}