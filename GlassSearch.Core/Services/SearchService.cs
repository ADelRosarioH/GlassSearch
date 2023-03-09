using GlassSearch.Core.Data;
using GlassSearch.Core.Models;

namespace GlassSearch.Core.Services;

public class SearchService : ISearchService
{
    public Task<ICollection<DocumentViewModel>> Search(string query, bool matchAll = false)
    {
        var results = LegacySearchService.SearchDocuments(query, matchAll)
            .Select(d => new DocumentViewModel
            {
                Id = d.Id,
                Title = d.Title,
                Content = d.Content
            }).ToList();

        return Task.FromResult<ICollection<DocumentViewModel>>(results);
    }
}