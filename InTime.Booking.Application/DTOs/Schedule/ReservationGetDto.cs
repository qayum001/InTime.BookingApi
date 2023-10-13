using AutoMapper;
using InTime.Booking.Domain.Entity.Schedule;
using InTime.Booking.Domain.Enum;

namespace InTime.Booking.Application.DTOs.Schedule
{
    public class ReservationGetDto
    {
        public BaseScheduleDto Schedule { get; }
        public Guid UserID { get; }
        public string Description { get; }
        public ReservationStatus Status { get; }

        public ReservationGetDto(BaseScheduleDto schedule, Guid userID, string description, ReservationStatus status)
        {
            Schedule = schedule ?? throw new ArgumentNullException(nameof(schedule));
            UserID = userID;
            Description = description;
            Status = status;
        }

        private class ReservationProfile : Profile
        {
            public ReservationProfile()
            {
                CreateMap<Reservation, ReservationGetDto>();
            }
        }
    }
}
