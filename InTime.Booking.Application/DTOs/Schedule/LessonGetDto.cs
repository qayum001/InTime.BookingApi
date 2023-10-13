using AutoMapper;
using InTime.Booking.Domain.Entity.Schedule;
using InTime.Booking.Domain.Entity.University;
using InTime.Booking.Domain.Entity.User;

namespace InTime.Booking.Application.DTOs.Schedule
{
    public class LessonGetDto
    {
        public BaseScheduleDto Schedule { get; }
        public Teacher Teacher { get; }
        public Guid TeacherId { get; }
        public Group Group { get; }
        public Guid GroupId { get; }

        public LessonGetDto(
            BaseScheduleDto schedule,
            Teacher teacher,
            Guid teacherId,
            Group group,
            Guid groupId)
        {
            Schedule = schedule;
            Teacher = teacher;
            TeacherId = teacherId;
            Group = group;
            GroupId = groupId;
        }

        private class LessonProfile : Profile
        {
            public LessonProfile()
            {
                CreateMap<Lesson, LessonGetDto>();
            }
        }
    }
}