using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Entity.User;

namespace InTime.Booking.Domain.Entity.Schedule
{
    public class Lesson : BaseEntity
    {
        public TimeSlot TimeSlot { get; private set; }
        public Teacher Teacher { get; private set; }
        public Guid TeacherId { get; private set; }
        public Group Group { get; private set; }
        public Guid GroupId { get; private set; }
        public Audience Audience { get; private set; }
        public Guid AudienceId { get; private set; }

        public Lesson(Guid id,
            string name,
            TimeSlot timeSlot,
            Teacher teacher,
            Group group,
            Audience audience) : base(id, name)
        {
            TimeSlot = timeSlot
                ?? throw new ArgumentNullException(nameof(TimeSlot), "TimeSlot can not be null");

            Teacher = teacher
                ?? throw new ArgumentNullException(nameof(Teacher), "Teacher can not be null");
            TeacherId = teacher.Id;

            Group = group
                ?? throw new ArgumentNullException(nameof(Group), "Group cannot be null");
            GroupId = group.Id;

            Audience = audience
                ?? throw new ArgumentNullException(nameof(Audience), "Audience cannot be null");
            AudienceId = Audience.Id;
        }
    }
}