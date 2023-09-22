using InTime.Booking.Domain.Common.Additional;
using InTime.Booking.Domain.Common.Extension;

namespace InTime.Booking.Domain.Entity.Schedule
{
    public class TimeSlot
    {   
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TimeSlot(int slot, DateTime date)
        {
            if (!Metrics.CanBeInSchedule(slot))
                throw new ArgumentException("Time slot must be in range 1-7", nameof(slot));

            SetLessonTime(slot, date);
        }

        public TimeSlot(DateTime start, DateTime end)
        {
            if (!Metrics.CanBeInSchedule(start.GetDayInSeconds(), end.GetDayInSeconds()))
                throw new ArgumentOutOfRangeException(nameof(start), nameof(end)
                    , "Start must be after 8:45 and End before than 21:50");
            if (!Metrics.IsAvailableDuration(start.GetDayInSeconds(), end.GetDayInSeconds()))
                throw new ArgumentOutOfRangeException(nameof(start), nameof(end)
                    , "Minimal Duration 15 minutes");

            Start = start;
            End = end;
        }

        private void SetLessonTime(int slot, DateTime date)
        {
            Start = new DateTime(date.Year, date.Month, date.Day)
                .AddSeconds(Metrics.GetLessonStartInSeconds(slot));

            End = new DateTime(date.Year, date.Month, date.Day)
                .AddSeconds(Metrics.GetLessonEndInSeconds(slot));
        }
    }
}