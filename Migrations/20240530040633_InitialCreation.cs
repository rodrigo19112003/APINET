using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backendnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Protected = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Synopsis = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoryMovie",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMovie", x => new { x.CategoriesCategoryId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Category_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Movie_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name", "Protected" },
                values: new object[,]
                {
                    { 1, "Acción", true },
                    { 2, "Aventura", true },
                    { 3, "Animación", true },
                    { 4, "Ciencia ficción", true },
                    { 5, "Comedia", true },
                    { 6, "Crimen", true },
                    { 7, "Documental", true },
                    { 8, "Drama", true },
                    { 9, "Familiar", true },
                    { 10, "Fantasia", true },
                    { 11, "Historia", true },
                    { 12, "Horror", true },
                    { 13, "Musica", true },
                    { 14, "Misterio", true },
                    { 15, "Romance", true }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Poster", "Synopsis", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "N/A", "El banquero Andy Dufresne es arrestado por matar a su esposa", "Sueño de fuga", 0 },
                    { 2, "N/A", "El patriarca de una organización criminal transfiere el cont", "El padrino", 0 },
                    { 3, "N/A", "Cuando el Joker emerge causando caos y violencia en", "El caballero oscuro", 0 },
                    { 4, "N/A", "Gandalf y Aragorn lideran el mundo de los hombres, e", "El retorno del rey", 0 },
                    { 5, "N/A", "Las vidas de dos mafiosos, un boxeador, la esposa de", "Tiempos violentos", 0 },
                    { 6, "N/A", "Las presidencias de Kennedy y Johnson, los eventos de Viet", "Forrest Gump", 0 },
                    { 7, "N/A", "Un hombre deprimido conoce a un fabricante de jabon", "El club de la pelea", 0 },
                    { 8, "N/A", "A un ladrón que roba secretos corporativos a través de la tec", "Inception", 0 },
                    { 9, "N/A", "Los rebeldes han vencido", "Star Wars: Episodio V - El imperio contraataca", 0 },
                    { 10, "N/A", "Un hacker se da cuenta por medio de otros rebeldes de la natura", "Matrix", 0 },
                    { 11, "N/A", "Un grupo de exploradores prueban los saltos a través de a", "Interestelar", 0 },
                    { 12, "N/A", "Paul Atreides se une a Chani y los Fremen mientras bus", "Dune: Parte dos", 0 },
                    { 13, "N/A", "Un cyborg, idéntico al que fracasó al as", "Terminator 2: El juicio final", 0 },
                    { 14, "N/A", "Marty McFly, un estudiante de 17 años, es enviado acc", "Volver al futuro", 0 },
                    { 15, "N/A", "Vivir en Barbie Land es ser un ser perfecto en un lugar perfect", "Barbie", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMovie_MoviesMovieId",
                table: "CategoryMovie",
                column: "MoviesMovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryMovie");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
