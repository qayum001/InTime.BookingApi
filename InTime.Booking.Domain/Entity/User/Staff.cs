using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Enum;

namespace InTime.Booking.Domain.Entity.User
{
    public class Staff : BaseUser
    {
        public Faculty Faculty { get; }
        public Staff(Guid id,
                     string name,
                     string email,
                     Faculty faculty) : base(id, name, email)
        {
            Faculty = faculty
                ?? throw new ArgumentNullException(nameof(Faculty), "Faculty can not be null");
        }
    }
}