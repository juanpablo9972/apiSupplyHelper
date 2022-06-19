using System.Text.Json.Serialization;

namespace apiSupplyHelper.Data.Models.Auth;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }
}
