namespace backendnet.Models;

public class MovieDTO
{
    public int? MovieId { get; set; }
    public required string Title { get; set; }
    public string Synopsis { get; set; } = "Without synopsis";
    public int Year { get; set; }
    public string Poster { get; set; } = "N/A";
    public int[]? Categories { get; set; }
}