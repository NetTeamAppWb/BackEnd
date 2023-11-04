using System.ComponentModel.DataAnnotations;

namespace A._API.Request;

public class RestaurantRequest
{
    [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Foods { get; set; }
    public int Schedule { get; set; }
    public string Location { get; set; }
    public string Owner { get; set; }
    public string Payment { get; set; }
    public int Calls { get; set; }
}