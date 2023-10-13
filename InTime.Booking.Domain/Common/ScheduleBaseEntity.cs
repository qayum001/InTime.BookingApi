using InTime.Booking.Domain.Entity.Schedule;
using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Enum;

namespace InTime.Booking.Domain.Common
{
    public class ScheduleBaseEntity : BaseEntity, IComparable<ScheduleBaseEntity>
    {
        public TimeSlot TimeSlot { get; }
        public Audience Audience { get; }
        public Guid AudienceId { get; }
        public Enum.Type Type { get; }
        public ScheduleBaseEntity(Guid id, string name, TimeSlot timeSlot, Audience audience, Enum.Type type) : base(id, name)
        {
            Type = type;

            TimeSlot = timeSlot
                ?? throw new ArgumentNullException(nameof(TimeSlot), "TimeSlot can not be null");

            Audience = audience
                ?? throw new ArgumentNullException(nameof(Audience), "Audience can not be null");
            AudienceId = audience.Id;
        }

        public int CompareTo(ScheduleBaseEntity? other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (TimeSlot.Start < other.TimeSlot.Start)
                return -1;
            if (TimeSlot.Start > other.TimeSlot.Start)
                return 1;

            return 0;
        }
    }
}
