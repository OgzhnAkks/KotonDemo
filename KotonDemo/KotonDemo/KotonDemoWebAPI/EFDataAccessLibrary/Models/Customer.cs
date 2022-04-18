using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EFDataAccessLibrary.Models;

public class Customer
{
    [JsonIgnore]
    public int CustomerId { get; set; }

    [Column(TypeName = "varchar(450)")]
    public string? Name { get; set; }

    [Column(TypeName = "varchar(450)")]
    public string? FirstName { get; set; }

    public List<Address> Addresses { get; set; }=new List<Address>();
}

