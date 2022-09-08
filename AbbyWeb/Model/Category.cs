using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }
    
    [Display(Name = "Display Order")]
    [Range(1, 100, ErrorMessage = "Display order must be between 1 and 100")]
    public int DisplayOrder { get; set; }
}