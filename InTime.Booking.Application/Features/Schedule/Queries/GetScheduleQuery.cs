using AutoMapper;
using InTime.Booking.Application.Common.Enum;
using InTime.Booking.Application.DTOs.Schedule;
using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Domain.Common;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace InTime.Booking.Application.Features.Schedule.Queries
{
    public class GetScheduleQuery : IRequest<ScheduleDto>
    {
        [Required]
        public ScheduleType Type { get; }
        [Required]
        public DateTime StartDate { get; }
        [Required]
        public DateTime EndDate { get; }
        [Required]
        public Guid Id { get; }

        public GetScheduleQuery(ScheduleType type, Guid id, DateTime dateFrom, DateTime dateTo)
        {
            Type = type; Id = id; StartDate = dateFrom; EndDate = dateTo;
        }
    }

    public class GetScheduleQueryHandler : IRequestHandler<GetScheduleQuery, ScheduleDto>
    {
        private readonly IScheduleRepository _scheduleRepository;

        public GetScheduleQueryHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<ScheduleDto> Handle(GetScheduleQuery query, CancellationToken cancellationToken)
        {
            var items = await _scheduleRepository.GetIntervalSchedule(query);         

            var sortedItems = new List<DayScheduleDto>();

            var startDate = items.First().TimeSlot.Start;
            var endDate = items.Last().TimeSlot.End;

            for (var i = startDate.Day; i <= endDate.Day; i++)
            {
                var dayItems = from item in items
                               where item.TimeSlot.Start.Day == i
                               select item;

                sortedItems.Add(new DayScheduleDto(dayItems.ToList(), dayItems.First().TimeSlot.Start));
            }

            return new ScheduleDto(sortedItems, startDate, endDate);
        }
    }
}