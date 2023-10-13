using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.University;

namespace InTime.Booking.Domain.Entity.User
{
    public class Student : BaseUser
    {
        public Group Group { get; private set; }
        public Guid GroupId { get; private set; }
        public Faculty Faculty { get; private set; }
        public Guid FacultyId { get; private set; }
        public Student(
            Guid id,
            string name,
            string email,
            Group group,
            Faculty faculty, AuthComponent authComponent) : base(id, name, email, authComponent)
        {
            Group = group
                ?? throw new ArgumentNullException(nameof(Group), "Group can not be null");
            GroupId = group.Id;
            Faculty = faculty
                ?? throw new ArgumentNullException(nameof(Faculty), "Faculty can not be null");

            this.AddRole(Enum.Role.STUDENT);
        }

    }
}