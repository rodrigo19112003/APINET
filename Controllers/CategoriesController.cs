using backendnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backendnet.Data;

namespace backendnet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(DataContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        return await context.Category.AsNoTracking().ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await context.Category.FindAsync(id);

        if (category == null) return NotFound();

        return category;
    }

    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(CategoryDTO categoryDTO)
    {
        Category category = new()
        {
            Name = categoryDTO.Name,
        };

        context.Category.Add(category);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.CategoryId) return BadRequest();

        var categoria = await context.Category.FindAsync(id);
        if(categoria == null) return NotFound();

        categoria.Name = categoryDTO.Name;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await context.Category.FindAsync(id);
        if (category == null) return NotFound();

        if(category.Protected) return BadRequest();
        
        context.Category.Remove(category);
        await context.SaveChangesAsync();

        return NoContent();
    }
}