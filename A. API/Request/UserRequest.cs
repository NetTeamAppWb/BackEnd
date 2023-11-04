using System.ComponentModel.DataAnnotations;

namespace A._API.Request;

public class UserRequest
{
    [Required]
    public string email { get; set; }
    public string password { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string phoneNumber { get; set; }
    public string description { get; set; }
    public int age { get; set; }
    public string paymentMethods { get; set; }
}