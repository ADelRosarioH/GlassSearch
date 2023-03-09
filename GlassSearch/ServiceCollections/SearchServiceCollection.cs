using GlassSearch.Core.Data;
using GlassSearch.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace GlassSearch.ServiceCollections;

public static class SearchServiceCollection
{
    public static IServiceCollection AddSearchService(this IServiceCollection services)
    {
        services.AddScoped<ISearchService>(provider =>
        {
            var context = provider.GetService<GlassDbContext>();
            LegacySearchService.Initialize(context);

            return new SearchService();
        });

        return services;
    } 
}