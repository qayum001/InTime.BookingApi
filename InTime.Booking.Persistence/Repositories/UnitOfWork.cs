using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Domain.Common;
using InTime.Booking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTime.Booking.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Hashtable _repositories;
        private bool disposed;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public void Dispose()
        {
            disposed = true;
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            _repositories ??= new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var respositoryInstance = Activator.
                    CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);

                _repositories.Add(type, respositoryInstance);
            }

            return (IGenericRepository<T>) _repositories[type];
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
