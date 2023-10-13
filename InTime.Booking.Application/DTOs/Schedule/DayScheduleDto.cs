using InTime.Booking.Domain.Common;

namespace InTime.Booking.Application.DTOs.Schedule
{
    public class DayScheduleDto
    {
        public DateTime Date { get; }
        public ICollection<ScheduleBaseEntity> ScheduleItems { get; }

        public DayScheduleDto(ICollection<ScheduleBaseEntity> items, DateTime date) 
        {
            Date = date;
            ScheduleItems = items;
        }
    }
}
