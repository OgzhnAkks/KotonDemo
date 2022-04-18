using System.Text.Json.Serialization;

namespace EFDataAccessLibrary.Models;

public class Discount
{
    [JsonIgnore]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int DiscountRate { get; set; }
}
