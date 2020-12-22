using CleanArchitecture.Domain.Settings;
using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDbGenericRepository;

namespace CleanArchitecture.Infrastructure.Identity
{
    public static class ServiceExtensions
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add our Config object to IOptions<T> so it can be injected
            // Nuget : Microsoft.Extensions.Options.ConfigurationExtensions
            // https://github.com/dotnet/AspNetCore.Docs/issues/18833
            services.Configure<MongoDbSettings>(configuration.GetSection(typeof(MongoDbSettings).Name));

            // Google : GetRequiredService vs GetService 
            // Recomended to use GetRequiredService
            var mongoDbSettings = services.BuildServiceProvider().GetRequiredService<IOptions<MongoDbSettings>>().Value;

            var mongoDbContext = new MongoDbContext(mongoDbSettings.AuhthorizedConnectionString, mongoDbSettings.Database);
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddMongoDbStores<IMongoDbContext>(mongoDbContext).AddDefaultTokenProviders();
        }
    }
}
