using Medical.API.Data;
using Medical.API.Features;
using Medical.API.Features.Medicine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Medical.API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<MedicineDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString()));

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddTransient<IMedicineService, MedicineService>();
                
        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Medical API", Version = "v1" });
                });
    }
}
