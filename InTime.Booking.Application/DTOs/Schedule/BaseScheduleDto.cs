using AutoMapper;
using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.Schedule;
using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Enum;

namespace InTime.Booking.Application.DTOs.Schedule
{
    public class BaseScheduleDto
    {  
        public Domain.Enum.Type Type { get; }
        public Guid Id { get; }
        public string Name { get; }
        public TimeSlot TimeSlot { get; }
        public Audience Audience { get; }


        public BaseScheduleDto(Guid id,
            string name,
            TimeSlot slot,
            Audience audience,
            Domain.Enum.Type type)
        {
            Id = id;
            Name = name;
            TimeSlot = slot;
            Audience = audience;
            Type = type;
        }

        private class BaseScheduleProfile : Profile
        {
            public BaseScheduleProfile()
            {
                CreateMap<ScheduleBaseEntity, BaseScheduleDto>();
            }
        }
    }
}
