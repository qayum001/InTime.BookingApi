namespace InTime.Booking.Domain.Common
{
    public class ScheduleBaseEntity : BaseEntity // gonna be removed
    {
        public DateTime Start { get; protected set; }
        public DateTime End { get; protected set; }
        public ScheduleBaseEntity(Guid id, string name) : base(id, name)
        {
        }
    }
}
