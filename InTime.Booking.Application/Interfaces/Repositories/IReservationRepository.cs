using InTime.Booking.Domain.Common;
using InTime.Booking.Domain.Entity.University;

namespace InTime.Booking.Application.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Task<Audience> GetAudienceAsync(Guid id);
        Task<BaseUser> GetUserAsync(Guid id);
    }
}
