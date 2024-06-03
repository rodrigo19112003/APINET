using System.Text.Json.Serialization;

namespace backendnet.Models;

public class Category
{
    public int CategoryId { get; set; }
    public required string Name { get; set;}
    public bool Protected { get; set; } = false;

    [JsonIgnore]
    public ICollection<Movie>? Movies { get; set; } 
}