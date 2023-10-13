using InTime.Booking.Application.Common.Enum;
using InTime.Booking.Application.DTOs.Schedule;
using InTime.Booking.Application.Features.Schedule.Queries;
using InTime.Booking.Application.Interfaces.Services.ScheduleServices;
using InTime.Booking.Domain.Common.Extension;
using InTime.Booking.Infrastructure.Refit.Interfaces;
using MediatR;
using System.Data;
using System.Runtime.CompilerServices;

namespace InTime.Booking.Infrastructure.Services.ScheduleServices
{
    public class ScheduleGetService : IScheduleGetService
    {
        private readonly IMediator _mediator;
        private readonly IInTimeClient _client;
        public ScheduleGetService(IMediator mediator, IInTimeClient client)
        {
            _mediator = mediator;
            _client = client;
        }

        public async Task<ScheduleDto> GetIntervalSchedule(GetScheduleQuery query)
        {

            if (query == null) 
                throw new NullReferenceException(nameof(query));

            var clientResponse = await _client.
                GetSchedulesAsync(GetType(query.Type), query.Id, query.StartDate.GetDayInString(), query.EndDate.GetDayInString());

            var contextResponse = await _mediator.Send(query);


        }

        private string GetType(ScheduleType type) => type switch
        {
            ScheduleType.professor => "professor",
            ScheduleType.audience => "audience",
            ScheduleType.group => "group",
            _ => throw new InvalidOperationException()
        };
            
    }
}