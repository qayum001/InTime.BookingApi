using InTime.Booking.Infrastructure.Refit.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Newtonsoft.Json;
using InTime.Booking.Persistence.DI;

namespace InTime.Booking.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRefit(configuration);
            services.AddPersistanceLayer(configuration);
        }

        private static void AddRefit(this IServiceCollection services, IConfiguration configuration)
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());

            services.AddRefitClient<IInTimeClient>(refitSettings)
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://test.intime.kreosoft.space/api/web/"));
        }
    }
}
