using System.ComponentModel.DataAnnotations;

namespace SteppaWeb.Models;

public class Customer
{
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Please enter the customer's name")]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
    public string Name { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "Phone can't be longer than 20 characters")]
    public string? Phone { get; set; }

    // One customer, many orders
    public List<Order> Orders { get; set; } = new();
}