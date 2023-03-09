using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GlassSearch.Core.Data;

public class GlassDbContextFactory : IDesignTimeDbContextFactory<GlassDbContext>
{
    public GlassDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.json"))
            .Build();

        var connectionString = config.GetConnectionString("GlassDb");

        var options = new DbContextOptionsBuilder<GlassDbContext>()
            .UseSqlServer(connectionString).Options;

        var context = new GlassDbContext(options);

        return context;
    }
}