using System.Reflection;
using GlassSearch.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlassSearch.Core.Data;

public class GlassDbContext : DbContext
{
    public virtual DbSet<Document> Documents { get; set; }
    public GlassDbContext(DbContextOptions<GlassDbContext> options)
        : base(options)        
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        var assembly = Assembly.GetExecutingAssembly();
        builder.ApplyConfigurationsFromAssembly(assembly);
    }
}