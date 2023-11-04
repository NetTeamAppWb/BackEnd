namespace Data.Model;

public class Base
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public bool IsActive { get; set; }
    public List<Restaurant> Restaurants { get; set; }
    
    
}