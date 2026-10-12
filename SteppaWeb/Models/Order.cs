using System.ComponentModel.DataAnnotations;

namespace SteppaWeb.Models;

public class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1,000")]
    public int Quantity { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
}