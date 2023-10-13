namespace InTime.Booking.Application.DTOs.Schedule
{
    public class ScheduleDto
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public ICollection<DayScheduleDto> ScheduleIntervalItems { get; }

        public ScheduleDto(
            ICollection<DayScheduleDto> scheduleIntervalItems,
            DateTime start,
            DateTime end) 
        { 
            ScheduleIntervalItems = scheduleIntervalItems;
            StartDate = start;
            EndDate = end;
        }
    }
}
