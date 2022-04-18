using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFDataAccessLibrary.Models;
public class Address
{
    [JsonIgnore]
    public int AddressId { get; set; }

    public string? StreetAddress { get; set; }

    [Column(TypeName = "varchar(250)")]
    public string? City { get; set; }

    [Column(TypeName = "varchar(250)")]
    public string? District { get; set; }

    [Column(TypeName = "varchar(10)")]
    public string? ZipCode { get; set; }
}
