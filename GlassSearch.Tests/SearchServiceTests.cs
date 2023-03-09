using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using GlassSearch.Core.Data;
using GlassSearch.Core.Data.Entities;
using GlassSearch.Core.Services;
using GlassSearch.Tests.Fixtures;
using Xunit;

namespace GlassSearch.Tests;

[Collection("GlassDb.Database")]
public class SearchServiceTests
{
    private readonly GlassDbContext _context;
    private readonly ISearchService _sut;
    
    public SearchServiceTests(GlassDbContextFixture fixture)
    {
        _context = fixture._context;
        LegacySearchService.Initialize(_context);
        
        _sut = new SearchService();
    }
    
    [Fact]
    public async Task Search_ShouldReturnAllDocuments_WhenQueryIsNullOrEmpty()
    {
        // Arrange
        var fixture = new Fixture();
        
        var doc = fixture.Build<Document>()
            .Without(d => d.Id)
            .Create();
        
        await _context.Documents.AddAsync(doc);
        await _context.SaveChangesAsync();
        
        // Act
        var results = await _sut.Search(query: string.Empty, matchAll: false);

        // Assert
        Assert.Single(results);
        Assert.Equal(doc.Id, results.First().Id);
    }
    
    [Fact]
    public async Task Search_ShouldReturnFoundDocuments_WhenQueryIsNotNullOrEmpty()
    {
        // Arrange
        var fixture = new Fixture();
        
        var doc = fixture.Build<Document>()
            .Without(d => d.Id)
            .With(d => d.Title, "test")
            .Create();
        
        await _context.Documents.AddAsync(doc);
        await _context.SaveChangesAsync();

        var query = "test";
        
        // Act
        var results = await _sut.Search(query: query, matchAll: false);

        // Assert
        Assert.Single(results);
        Assert.Equal(doc.Id, results.First().Id);
    }
    
    [Fact]
    public async Task Search_ShouldReturnFoundDocuments_WhenQueryIsNotNullOrEmptyAndMatchAllIsTrue()
    {
        // Arrange
        var fixture = new Fixture();
        
        var doc = fixture.Build<Document>()
            .Without(d => d.Id)
            .With(d => d.Title, "test 123")
            .Create();
        
        await _context.Documents.AddAsync(doc);
        await _context.SaveChangesAsync();

        var query = "test 123";
        
        // Act
        var results = await _sut.Search(query: query, matchAll: true);

        // Assert
        Assert.Single(results);
        Assert.Equal(doc.Id, results.First().Id);
    }
    
    [Fact]
    public async Task Search_ShouldReturnEmpty_WhenQueryIsNotNullOrEmptyAndMatchAllIsTrue()
    {
        // Arrange
        var fixture = new Fixture();
        
        var doc = fixture.Build<Document>()
            .Without(d => d.Id)
            .With(d => d.Title, "test 123")
            .Create();
        
        await _context.Documents.AddAsync(doc);
        await _context.SaveChangesAsync();

        var query = "test";
        
        // Act
        var results = await _sut.Search(query: query, matchAll: true);

        // Assert
        Assert.Empty(results);
    }
    
    [Fact]
    public async Task Search_ShouldReturnDocuments_WhenQueryIsNotNullOrEmptyAndMatchAllIsFalse()
    {
        // Arrange
        var fixture = new Fixture();
        
        var doc = fixture.Build<Document>()
            .Without(d => d.Id)
            .With(d => d.Title, "test 123")
            .Create();
        
        await _context.Documents.AddAsync(doc);
        await _context.SaveChangesAsync();

        var query = "test";
        
        // Act
        var results = await _sut.Search(query: query, matchAll: false);

        // Assert
        Assert.Single(results);
        Assert.Equal(doc.Id, results.First().Id);
    }
}