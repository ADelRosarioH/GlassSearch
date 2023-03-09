using GlassSearch.Core.Data;
using GlassSearch.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlassSearch.Core.Services;

public static class LegacySearchService
{
    private static bool _initialized = false;
    private static GlassDbContext _context;
    
    public static void Initialize(GlassDbContext context)
    {
        _context = context;
        _initialized = true;
    }

    public static List<Document> SearchDocuments(string query, bool matchAll)
    {
        if (!_initialized)
        {
            throw new Exception($"{nameof(LegacySearchService)} must be initialized prior to used.");
        }

        if (string.IsNullOrEmpty(query))
        {
            return _context.Documents.ToList();
        }

        var results = _context.Documents
            .Where(d => (matchAll 
                            ? string.Equals(d.Id.ToString(), query) 
                            : EF.Functions.Like(d.Id.ToString(), $"%{query}%")) ||
                        (matchAll 
                            ? string.Equals(d.Title, query) 
                            : EF.Functions.Like(d.Title, $"%{query}%")) ||
                        (matchAll 
                            ? string.Equals(d.Content, query) 
                            : EF.Functions.Like(d.Content, $"%{query}%")))
            .ToList();

        return results;
    }
}