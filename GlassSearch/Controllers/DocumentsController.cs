using GlassSearch.Core.Models;
using GlassSearch.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlassSearch.Controllers;

[ApiController]
[Route("[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly ISearchService _searchService;

    public DocumentsController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<DocumentViewModel>>> Search([FromQuery] string? query = "",
        [FromQuery] bool matchAll = false)
    {
        var results = await _searchService.Search(query, matchAll);
        return Ok(results);
    }
}