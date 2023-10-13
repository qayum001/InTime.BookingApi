using AutoMapper;
using InTime.Booking.Domain.Common;

namespace InTime.Booking.Application.Mapper
{
    public class IntervalScheduleMapper : Profile
    {
        public IntervalScheduleMapper() 
        {
            CreateMap<ICollection<ScheduleBaseEntity>, IntervalScheduleMapper>();
        }
    }
}
