using System.ComponentModel.DataAnnotations;

namespace apiSupplyHelper.Data.Models.Auth;

public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Telefono { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

}
