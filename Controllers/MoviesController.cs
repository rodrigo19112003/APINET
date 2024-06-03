using backendnet.Models;
using backendnet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController(DataContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(string? s)
    {
        if (string.IsNullOrEmpty(s))
            return await context.Movie.Include(i => i.Categories).AsNoTracking().ToListAsync();
        
        return await context.Movie.Include(i => i.Categories).Where(c => c.Title.Contains(s)).AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        var movie = await context.Movie.Include(i => i.Categories).AsNoTracking().FirstOrDefaultAsync(s => s.MovieId == id);
        if (movie == null) return NotFound();

        return movie;
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> PostMovie(MovieDTO movieDTO)
    {
        Movie movie = new()
        {
            Title = movieDTO.Title,
            Synopsis = movieDTO.Synopsis,
            Year = movieDTO.Year,
            Poster = movieDTO.Poster,
            Categories = []
        };

        context.Movie.Add(movie);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMovie), new { id = movie.MovieId }, movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMovie(int id, MovieDTO movieDTO)
    {
        if (id != movieDTO.MovieId) return BadRequest();

        var movie = await context.Movie.FirstOrDefaultAsync(s => s.MovieId == id);
        if(movie == null) return NotFound();

        movie.Title = movieDTO.Title;
        movie.Synopsis = movieDTO.Synopsis;
        movie.Year = movieDTO.Year;
        movie.Poster = movieDTO.Poster;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var pelicula = await context.Movie.FindAsync(id);
        if (pelicula == null) return NotFound();

        context.Movie.Remove(pelicula);
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("{id}/categoria")]
    public async Task<IActionResult> PostMovieCategory(int id, AssignCategoryDTO itemToAdd)
    {
        Category? category = await context.Category.FindAsync(itemToAdd.CategoryId);
        if (category == null) return NotFound();

        var pelicula = await context.Movie.Include(i => i.Categories).FirstOrDefaultAsync(s => s.MovieId == id);
        if (pelicula == null) return NotFound();

        if (pelicula?.Categories?.FirstOrDefault(category) != null)
        {
            pelicula.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        return NoContent();
    }

    [HttpDelete("{id}/category/{categoryId}")]
    public async Task<IActionResult> DeleteMovieCategory(int id, string categoryId)
    {
        Category? category = await context.Category.FindAsync(categoryId);
        if (category == null) return NotFound();

        var movie = await context.Movie.Include(i => i.Categories).FirstOrDefaultAsync(s => s.MovieId == id);
        if (movie == null) return NotFound();

        if (movie?.Categories?.FirstOrDefault(category) != null)
        {
            movie.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

        return NoContent();
    }
}