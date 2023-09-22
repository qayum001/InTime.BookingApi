using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Common.Additional;
using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Entity.User;
using InTime.Booking.Domain.Enum;

namespace InTime.Booking.Domain.Entity.Schedule
{
    public class Reservation : BaseEntity
    {
        public TimeSlot TimeSlot { get; private set; }
        public Audience Audience { get; private set; }
        public Guid AudienceId { get; private set; }
        public BaseUser User { get; private set; }
        public Guid UserId { get; private set; }
        public string Description { get; private set; }
        public Guid ApprovedAdminId { get; private set; }
        public ReservationStatus ReservationStatus { get; private set; }
        public Reservation(
            Guid id,
            string name,
            TimeSlot slot,
            BaseUser user,
            Audience audience,
            string description) : base(id, name)
        {
            TimeSlot = slot
                ?? throw new ArgumentNullException(nameof(TimeSlot), "TimeSlot can not be null");
            User = user
                ?? throw new ArgumentNullException(nameof(User), "User can not be null");
            UserId = user.Id;

            Audience = audience
                ?? throw new ArgumentNullException(nameof(Audience), "Audience can not be null");
            AudienceId = audience.Id;

            Description = string.IsNullOrEmpty(description) 
                ? throw new ArgumentNullException(nameof(Description), "Description can not be null or empty") : description;
        }

        public Task<Response> Approve(Guid approverId)
        {
            if (Appre)
            ApprovedAdminId = approverId;
        }
    }
}