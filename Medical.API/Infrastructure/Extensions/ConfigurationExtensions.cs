using Microsoft.Extensions.Configuration;

namespace Medical.API.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");
    }
}
