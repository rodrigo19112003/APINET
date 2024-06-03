namespace backendnet.Models;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; } = "Without title";
    public string Synopsis { get; set; } = "Without synopsis";
    public int Year { get; set; }
    public string Poster { get; set; } = "N/A";

    public ICollection<Category>? Categories{ get; set; }
}