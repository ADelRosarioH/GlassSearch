using GlassSearch.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace GlassSearch.ServiceCollections;

public static class GlassDbContextServiceCollection
{
    public static IServiceCollection AddGlassDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GlassDbContext>(
            opts => opts.UseSqlServer(configuration.GetConnectionString("GlassDb"),
                b => b.MigrationsAssembly(typeof(GlassDbContext).Assembly.FullName)));

        return services;
    } 
}