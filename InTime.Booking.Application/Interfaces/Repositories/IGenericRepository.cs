using InTime.Booking.Domain.Common;

namespace InTime.Booking.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> Entities { get; }

        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}