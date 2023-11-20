using System.ComponentModel.DataAnnotations;

namespace Data.Model;

public class Food : Base
{
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    
    // Referencia a Restaurant (de muchos a 1)
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    
}