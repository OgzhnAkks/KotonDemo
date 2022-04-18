using System.Text.Json.Serialization;

namespace EFDataAccessLibrary.Models;

public class Taxe
{
    [JsonIgnore]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int TaxeRate { get; set; }
}
