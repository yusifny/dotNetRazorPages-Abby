using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

public class Index : PageModel
{
    private readonly AppDbContext _context;
    public IEnumerable<Category> Categories { get; set; }
    public Index(AppDbContext context)
    {
        _context = context;
    }
    
    public void OnGet()
    {
        Categories = _context.Category;
    }
}