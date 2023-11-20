using System.ComponentModel.DataAnnotations;

namespace A._API.Request;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name_Rest { get; set; }
    public string Schedule { get; set; }
    public string Location { get; set; }
    public string Category { get; set; }
    public List<string> PaymentMethods { get; set; }
    public string Calls { get; set; }

    public BusinessmanDto Businessman { get; set; }
    public List<FoodDto> Foods { get; set; }
}

