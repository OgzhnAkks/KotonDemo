using System.Text.Json.Serialization;

namespace EFDataAccessLibrary.Models;

public class Order
{
    [JsonIgnore]
    public int Id { get; set; }

    public int ProductId { get; set; }

    public Customer Customer { get; set; }

    public Biling Biling { get; set; }

    public int Quantity { get; set; }

    [JsonIgnore]
    public string? Status { get; set; }
}
