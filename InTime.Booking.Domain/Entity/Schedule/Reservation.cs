using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Common.Additional;
using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Entity.User;
using InTime.Booking.Domain.Enum;

namespace InTime.Booking.Domain.Entity.Schedule
{
    public class Reservation : ScheduleBaseEntity
    {
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
            string description) : base(id, name, slot, audience, Enum.Type.RESERVATION)
        {
            User = user
                ?? throw new ArgumentNullException(nameof(User), "User can not be null");
            UserId = user.Id;

            Description = string.IsNullOrEmpty(description) 
                ? throw new ArgumentNullException(nameof(Description), "Description can not be null or empty") : description;

            ReservationStatus = ReservationStatus.Pending;
        }

        public Task<Response> Approve(Guid approverId)
        {
            if (approverId == Guid.Empty)
                return Task.FromResult(new Response(false, "Guid can not be empty"));

            ReservationStatus = ReservationStatus.Approved;
            ApprovedAdminId = approverId;

            return Task.FromResult(new Response(true, "Approved admin guid is set"));
        }

        public Task<Response> Deny(Guid approverId) {
         ReservationStatus = ReservationStatus.Approved;
            if (approverId == Guid.Empty)
                return Task.FromResult(new Response(false, "Guid can not be empty"));

            ReservationStatus = ReservationStatus.Approved;
            ApprovedAdminId = approverId;

            return Task.FromResult(new Response(true, "Denied admin guid is set"));
        }
    }
}