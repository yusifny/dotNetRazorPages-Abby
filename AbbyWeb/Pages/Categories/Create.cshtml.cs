using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories;

[BindProperties]

public class CreateModel : PageModel
{
    public Category Category { get; set; }
    
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError(string.Empty, "Name and Display Order cannot be the same");
        }
        if (ModelState.IsValid)
        {
            await _context.Category.AddAsync(Category);
            await _context.SaveChangesAsync();
            TempData["Success"] = $"Category {@Category.Name} created successfully";
            return RedirectToPage(nameof(Index));
        }

        return Page();
    }
}