using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFDataAccessLibrary.Models;

public class Biling
{
    [JsonIgnore]
    public int Id { get; set; }

    [JsonIgnore]
    [Column(TypeName = "decimal(18,4)")]
    public decimal ItemPrice { get; set; }

    [JsonIgnore]
    [Column(TypeName = "decimal(18,4)")]
    public decimal? TotalCost { get; set; }

    public List<Discount> Discounts { get; set; } = new List<Discount>();

    public List<Taxe> Taxes { get; set; } = new List<Taxe>();
}
