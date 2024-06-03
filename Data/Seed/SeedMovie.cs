using backendnet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backendnet.Data.Seed;

public class SeedMovie : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasData(
            new Movie { MovieId = 1, Title = "Sueño de fuga", Synopsis = "El banquero Andy Dufresne es arrestado por matar a su esposa"},
            new Movie { MovieId = 2, Title = "El padrino", Synopsis = "El patriarca de una organización criminal transfiere el cont"},
            new Movie { MovieId = 3, Title = "El caballero oscuro", Synopsis = "Cuando el Joker emerge causando caos y violencia en"},
            new Movie { MovieId = 4, Title = "El retorno del rey", Synopsis = "Gandalf y Aragorn lideran el mundo de los hombres, e"},
            new Movie { MovieId = 5, Title = "Tiempos violentos", Synopsis = "Las vidas de dos mafiosos, un boxeador, la esposa de"},
            new Movie { MovieId = 6, Title = "Forrest Gump", Synopsis = "Las presidencias de Kennedy y Johnson, los eventos de Viet"},
            new Movie { MovieId = 7, Title = "El club de la pelea", Synopsis = "Un hombre deprimido conoce a un fabricante de jabon"},
            new Movie { MovieId = 8, Title = "Inception", Synopsis = "A un ladrón que roba secretos corporativos a través de la tec"},
            new Movie { MovieId = 9, Title = "Star Wars: Episodio V - El imperio contraataca", Synopsis = "Los rebeldes han vencido"},
            new Movie { MovieId = 10, Title = "Matrix", Synopsis = "Un hacker se da cuenta por medio de otros rebeldes de la natura"},
            new Movie { MovieId = 11, Title = "Interestelar", Synopsis = "Un grupo de exploradores prueban los saltos a través de a"},
            new Movie { MovieId = 12, Title = "Dune: Parte dos", Synopsis = "Paul Atreides se une a Chani y los Fremen mientras bus"},
            new Movie { MovieId = 13, Title = "Terminator 2: El juicio final", Synopsis = "Un cyborg, idéntico al que fracasó al as"},
            new Movie { MovieId = 14, Title = "Volver al futuro", Synopsis = "Marty McFly, un estudiante de 17 años, es enviado acc"},
            new Movie { MovieId = 15, Title = "Barbie", Synopsis = "Vivir en Barbie Land es ser un ser perfecto en un lugar perfect"}
        );
    }
}