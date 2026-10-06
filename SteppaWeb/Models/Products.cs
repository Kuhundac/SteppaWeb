namespace SteppaWeb.Models;

using System.ComponentModel.DataAnnotations;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Color { get; set; }

    [Range(0, double.MaxValue)]
    public double Price { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }
}