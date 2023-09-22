using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.University;

namespace InTime.Booking.Domain.Entity.User
{
    public class Teacher : BaseUser
    {
        public List<Faculty> Faculties { get; } = new List<Faculty>();
        public Teacher(Guid id,
            string name,
            string email) : base(id, name, email)
        {

        }
    }
}