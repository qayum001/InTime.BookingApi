using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Domain.Common;
using InTime.Booking.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InTime.Booking.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Entities => _context.Set<T>();

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id)
                ?? throw new Exception($"{nameof(T)} not found");
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.
                Set<T>().
                ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            T item = await _context.Set<T>().FindAsync(entity.Id)
                ?? throw new Exception($"{nameof(T)} not found");

             _context.Entry(item).CurrentValues.SetValues(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }
}
