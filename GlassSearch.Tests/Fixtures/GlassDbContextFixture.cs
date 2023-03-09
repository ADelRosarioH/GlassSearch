using System;
using System.Linq;
using AutoFixture;
using GlassSearch.Core.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GlassSearch.Tests.Fixtures;

[CollectionDefinition("GlassDb.Database")]
public class GlassDbContextCollection : ICollectionFixture<GlassDbContextFixture>
{
    /*
     * This class has no code, and is never created.
     * Its purpose is simply to be the place to apply [CollectionDefinition] and all the
     * ICollectionFixture<> interfaces.
     * XUnit docs: https://xunit.net/docs/shared-context#collection-fixture
     */
}

public class GlassDbContextFixture : IDisposable
{
    private static readonly Fixture Fixture = new();
    public readonly GlassDbContext _context;

    static GlassDbContextFixture()
    {
        Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => Fixture.Behaviors.Remove(b));
        
        Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    public GlassDbContextFixture()
    {
        var options = new DbContextOptionsBuilder<GlassDbContext>()
            .UseInMemoryDatabase(databaseName: $"GlassDb.Database.{Guid.NewGuid()}")
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .Options;

        _context = new GlassDbContext(options);

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}