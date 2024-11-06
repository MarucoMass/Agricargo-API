

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Agricargo.Domain.Entities;

public class Company : User
{
    [Required]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
    public string CompanyName { get; set; } = default!;
    [JsonIgnore]
    public List<Ship> Ships { get; set; }
}
