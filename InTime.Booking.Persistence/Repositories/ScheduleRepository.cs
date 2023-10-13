using InTime.Booking.Application.Common.Enum;
using InTime.Booking.Application.Features.Schedule.Queries;
using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.Schedule;
using InTime.Booking.Persistence.Context;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace InTime.Booking.Persistence.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public ScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<ScheduleBaseEntity>> GetIntervalSchedule(GetScheduleQuery getDaySchedule) => getDaySchedule.Type switch
        {
            ScheduleType.audience => await GetAudienceSchedule(getDaySchedule),
            ScheduleType.group => await GetGroupSchedule(getDaySchedule),
            ScheduleType.professor => await GetProfessorSchedule(getDaySchedule),
            _ => throw new InvalidOperationException()
        };

        private Task<IQueryable<ScheduleBaseEntity>> GetPrimarySchedule(GetScheduleQuery getDaySchedule)
        {
            var res = _context.Schedule.
                Where(e =>
                e.TimeSlot.Start >= getDaySchedule.StartDate
                && e.TimeSlot.End <= getDaySchedule.EndDate);

            return Task.FromResult(res);
        }

        private async Task<IQueryable<ScheduleBaseEntity>> GetGroupSchedule(GetScheduleQuery getDaySchedule)
        {
            var primary = await GetPrimarySchedule(getDaySchedule);

            var res = primary.
                Where(e => e.Type == Domain.Enum.Type.LESSON);

            return res;
        }

        private async Task<IQueryable<ScheduleBaseEntity>> GetAudienceSchedule(GetScheduleQuery getDaySchedule)
        {
            var primary = await GetPrimarySchedule(getDaySchedule);

            var res = primary.
                Where(e => e.AudienceId == getDaySchedule.Id);

            return res;
        }

        private async Task<IQueryable<ScheduleBaseEntity>> GetProfessorSchedule(GetScheduleQuery getDaySchedule)
        {
            var primaty = await GetPrimarySchedule(getDaySchedule);                
            
            var res = primaty.
                OfType<Lesson>().
                Where(e => e.TeacherId == getDaySchedule.Id).
                Cast<ScheduleBaseEntity>();

            return res;
        }
    }
}
