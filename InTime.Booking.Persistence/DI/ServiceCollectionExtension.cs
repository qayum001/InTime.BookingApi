using InTime.Booking.Application.Interfaces.Repositories;
using InTime.Booking.Persistence.Repositories;
using InTime.Booking.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InTime.Booking.Persistence.DI
{
    public static class ServiceCollectionExtension
    {
        public static void AddPersistanceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddRepositories();
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration["ConnectionString:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connection));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
        }
    }
}