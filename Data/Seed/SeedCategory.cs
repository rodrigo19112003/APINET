using backendnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendnet.Data.Seed;

public class SeedCategory : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category { CategoryId = 1, Name = "Acción", Protected = true},
            new Category { CategoryId = 2, Name = "Aventura", Protected = true},
            new Category { CategoryId = 3, Name = "Animación", Protected = true},
            new Category { CategoryId = 4, Name = "Ciencia ficción", Protected = true},
            new Category { CategoryId = 5, Name = "Comedia", Protected = true},
            new Category { CategoryId = 6, Name = "Crimen", Protected = true},
            new Category { CategoryId = 7, Name = "Documental", Protected = true},
            new Category { CategoryId = 8, Name = "Drama", Protected = true},
            new Category { CategoryId = 9, Name = "Familiar", Protected = true},
            new Category { CategoryId = 10, Name = "Fantasia", Protected = true},
            new Category { CategoryId = 11, Name = "Historia", Protected = true},
            new Category { CategoryId = 12, Name = "Horror", Protected = true},
            new Category { CategoryId = 13, Name = "Musica", Protected = true},
            new Category { CategoryId = 14, Name = "Misterio", Protected = true},
            new Category { CategoryId = 15, Name = "Romance", Protected = true}
        );
    }
}