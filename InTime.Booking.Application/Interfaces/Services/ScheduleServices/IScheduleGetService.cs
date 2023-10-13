using InTime.Booking.Application.DTOs.Schedule;
using InTime.Booking.Application.Features.Schedule.Queries;

namespace InTime.Booking.Application.Interfaces.Services.ScheduleServices
{
    public interface IScheduleGetService
    {
        Task<ScheduleDto> GetIntervalSchedule(GetScheduleQuery getScheduleIntervalQuery);
    }
}