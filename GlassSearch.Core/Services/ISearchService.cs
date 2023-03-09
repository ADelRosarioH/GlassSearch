using GlassSearch.Core.Models;

namespace GlassSearch.Core.Services;

public interface ISearchService
{
    Task<ICollection<DocumentViewModel>> Search(string query, bool matchAll = false);
}