namespace Data.Model;

public class Restaurant : Base
{
    public string? Name_Rest { get; set; }
    public string? Schedule { get; set; }
    public string? Location { get; set; }
    public string? Category { get; set; }
    public List<string>? PaymentMethods { get; set; }
    public string? Calls { get; set; }
    
    // Referencia a Businessman (de 1 a 1)
    public int BusinessmanId { get; set; }
    public Businessman Businessman { get; set; }
    
    // Referencia a Food (de 1 restaurante a muchas comidas)
    public List<Food> Foods { get; set; }
    
}