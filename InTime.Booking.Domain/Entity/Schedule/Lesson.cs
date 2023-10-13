using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Entity.User;

namespace InTime.Booking.Domain.Entity.Schedule
{
    public class Lesson : ScheduleBaseEntity
    {
        public Teacher Teacher { get; private set; }
        public Guid TeacherId { get; private set; }
        public Group Group { get; private set; }
        public Guid GroupId { get; private set; }

        public Lesson(Guid id,
            string name,
            TimeSlot timeSlot,
            Teacher teacher,
            Group group,
            Audience audience) : base(id, name, timeSlot, audience, Enum.Type.LESSON)
        {
            Teacher = teacher
                ?? throw new ArgumentNullException(nameof(Teacher), "Teacher can not be null");
            TeacherId = teacher.Id;

            Group = group
                ?? throw new ArgumentNullException(nameof(Group), "Group cannot be null");
            GroupId = group.Id;
        }
    }
}