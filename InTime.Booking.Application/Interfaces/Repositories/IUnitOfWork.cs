using InTime.Booking.Domain.Common;

namespace InTime.Booking.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> SaveAsync(CancellationToken cancellationToken);
    }
}
