using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

[BindProperties]

public class EditModel : PageModel
{
    public Category Category { get; set; }
    
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet(int id)
    {
        Category = _context.Category.Find(id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError(string.Empty, "Name and Display Order cannot be the same");
        }
        if (ModelState.IsValid)
        {
            _context.Category.Update(Category);
            await _context.SaveChangesAsync();
            TempData["Success"] = $"Category {@Category.Name} updated successfully";
            return RedirectToPage(nameof(Index));
        }

        return Page();
    }
}