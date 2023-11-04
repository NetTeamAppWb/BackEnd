namespace Data.Model;

public class Base
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public bool IsActive { get; set; }
    public List<Restaurant> Restaurants { get; set; }
    public List<User> Users { get; set; }
    
    
}