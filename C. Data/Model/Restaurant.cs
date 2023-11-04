namespace Data.Model;

public class Restaurant : Base
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Foods { get; set; }
    public int? Schedule { get; set; }
    public string? Location { get; set; }
    public string? Owner { get; set; }
    public string? Payment { get; set; }
    public int? Calls { get; set; }
  
    
    //Relationa
    public int BaseId { get; set; }
    public Base Base { get; set; }
    
    
}