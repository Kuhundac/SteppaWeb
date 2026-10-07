using System.ComponentModel.DataAnnotations;

namespace SteppaWeb.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Please enter your email")]
    [EmailAddress(ErrorMessage = "That doesn't look like a valid email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}