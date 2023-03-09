using Bogus;
using GlassSearch.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlassSearch.Core.Data.Configurations;

public class DocumentSeedConfiguration : IEntityTypeConfiguration<Document>
{
    private readonly GlassDbContext _context;

    public DocumentSeedConfiguration(GlassDbContext context)
    {
        _context = context;
    }
    
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        if (_context.Documents.Any())
        {
            builder.HasData(_context.Documents.ToList()
                .Select(d => new Document
                {
                    Id = d.Id,
                    Title = d.Title,
                    Content = d.Content
                }));
            
            return;
        }
        
        var faker = new Faker<Document>()
            .Ignore(d => d.Id)
            .RuleFor(d => d.Title, f => string.Join(" ", f.Lorem.Words()))
            .RuleFor(d => d.Content, f => f.Lorem.Paragraph());
        
        foreach (var i in Enumerable.Range(1, 10)
                     .ToList())
        {
            var fake = faker.Generate();

            builder.HasData(new Document
            {
                Id = i,
                Title = fake.Title,
                Content = fake.Content
            });
        }
    }
}