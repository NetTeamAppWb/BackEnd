using System.ComponentModel.DataAnnotations;

namespace Data.Model;

public class Businessman : Base
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Description { get; set;}
    
    /*
    // Referencia a Restaurant (de 1 a 1)
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    */
}