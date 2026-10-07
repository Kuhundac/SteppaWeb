using System.ComponentModel.DataAnnotations;

namespace SteppaWeb.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Please enter your email")]
    [EmailAddress(ErrorMessage = "That doesn't look like a valid email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter your password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}