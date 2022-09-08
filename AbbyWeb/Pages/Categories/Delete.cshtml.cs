using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

[BindProperties]

public class DeleteModel : PageModel
{
    public Category Category { get; set; }
    
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet(int id)
    {
        Category = _context.Category.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        var categoryFromDb = _context.Category.Find(Category.Id);
        if (categoryFromDb != null)
        {
            _context.Category.Remove(categoryFromDb);
            await _context.SaveChangesAsync();
            TempData["Success"] = $"Category {@categoryFromDb.Name} deleted successfully";
            return RedirectToPage(nameof(Index));
        }
        return Page();
    }
}