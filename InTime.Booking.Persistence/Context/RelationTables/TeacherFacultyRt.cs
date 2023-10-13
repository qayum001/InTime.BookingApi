using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Entity.User;

namespace InTime.Booking.Persistence.Context.RelationTables
{
    public class TeacherFacultyRt
    {
        public Guid Id { get; }
        public Faculty Faculty { get; }
        public Guid FacultyId { get; }
        public Teacher Teacher { get; }
        public Guid TeacherId { get; }
    }
}
