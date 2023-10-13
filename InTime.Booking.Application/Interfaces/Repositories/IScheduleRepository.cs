using InTime.Booking.Application.Features.Schedule.Queries;
using InTime.Booking.Domain.Common;

namespace InTime.Booking.Application.Interfaces.Repositories
{
    public interface IScheduleRepository
    {
        Task<IQueryable<ScheduleBaseEntity>> GetIntervalSchedule(GetScheduleQuery getDaySchedule);
    }
}
