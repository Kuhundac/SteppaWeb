using System.ComponentModel.DataAnnotations;

namespace SteppaWeb.Models;

public class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Please enter a sock name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a color")]
    public string Color { get; set; } = string.Empty;

    [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000")]
    public double Price { get; set; }

    [Range(0, 100000, ErrorMessage = "Stock must be between 0 and 100,000")]
    public int StockQuantity { get; set; }
}