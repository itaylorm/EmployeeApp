using System.ComponentModel.DataAnnotations;

namespace iMaxwell.EmployeeClient.Models;

public class AuthenticationModel
{
    [Required(ErrorMessage = "User name is required")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}
