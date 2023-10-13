using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.User;
using System.Data;

namespace InTime.Booking.Domain.Entity.University
{
    public class Group : BaseEntity
    {
        public ICollection<Student> Students { get; } = new List<Student>(); // List type can be IReadonlyList if there is not student add/remove logic
        public Faculty Faculty { get; }
        public Guid FacultyId { get; }
        public Group(Guid id, string name, Faculty faculty) : base(id, name)
        {
            Faculty = faculty
                ?? throw new ArgumentNullException(nameof(Faculty), "Faculty can not be null");
            FacultyId = faculty.Id;
        }
    }
}