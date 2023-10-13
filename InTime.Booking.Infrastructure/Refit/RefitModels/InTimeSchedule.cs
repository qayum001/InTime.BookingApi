using InTime.Booking.Infrastructure.Refit.RefitModels.ScheduleClasses;

namespace InTime.Booking.Infrastructure.Refit.RefitModels
{
    public class InTimeSchedule
    {
        public DateTime Date { get; set; }
        public IEnumerable<EmptyLessonGrid> Schedule {  get; set; }
    }
}
