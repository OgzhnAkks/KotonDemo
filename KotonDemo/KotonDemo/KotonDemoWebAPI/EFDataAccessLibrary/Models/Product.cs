using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFDataAccessLibrary.Models;

public class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; }
}
