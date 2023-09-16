using System;
using Microsoft.EntityFrameworkCore.Migrations;
using static System.Net.WebRequestMethods;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                    table.ForeignKey(
                        name: "FK_Peliculas_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_GeneroId",
                table: "Peliculas",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");

            // Carga generos
            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Acción" });

            
            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Aventuras" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Ciencia Ficcion" });
            
            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Comedia" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Documental" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Drama" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Fantasía," });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Musical,," });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Suspense" });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Nombre" },
                values: new object[] { "Terror" });

            // Carga de Salas

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala 1", 5 });
            
            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala 2", 15 });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "Nombre", "Capacidad" },
                values: new object[] { "Sala 3", 35 });

            // Add pelicula 

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
            values: new object[] { "Rambo: First Blood",
                                        "Un veterano es obligado a huir a las montañas y librar una guerra de un solo hombre contra sus perseguidores.", 
                                        "https://pics.filmaffinity.com/rambo_first_blood-572528533-large.jpg",
                                        "https://www.youtube.com/watch?v=IAqLKlxY3Eo",
                                        1 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Batman: El caballero de la noche",
                                        "Cuando el Joker emerge causando caos y violencia en Gotham, el caballero de la noches deberá aceptar una de las pruebas psicológicas y físicas más difíciles para poder luchar con las injusticias del enemigo." ,
                                        "https://i.pinimg.com/564x/bc/40/ac/bc40ac181d2d738aac06b6e738c73df8.jpg",
                                        "https://www.youtube.com/watch?v=dzQtWkpc2-c",
                                        1 });
            
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Indiana Jones y la ultima cruzada",
                                        "El arqueólogo Indiana Jones y su padre se unen en una aventura para encontrar el Santo Grial antes que los nazis, enfrentando peligros, traiciones y revelaciones familiares.",
                                        "https://pics.filmaffinity.com/indiana_jones_and_the_last_crusade-834556032-large.jpg",
                                        "https://www.youtube.com/watch?v=DKg36LBVgfg",
                                        2 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "The Goonies",
                                        "Un grupo de niños busca un tesoro pirata para salvar sus hogares de ser demolidos, enfrentando trampas mortales y una banda de criminales en una emocionante aventura llena de amistad y valentía." ,
                                        "https://pics.filmaffinity.com/the_goonies-301424062-large.jpg",
                                        "https://www.youtube.com/watch?v=lYLAGAwcpSQ",
                                        2 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Alien: El octavo pasajero",
                                        "En el espacio, la tripulación de la nave Nostromo enfrenta un aterrador alienígena que acecha, desencadenando lucha por supervivencia en un thriller claustrofóbico." ,
                                        "https://pics.filmaffinity.com/alien-657278575-large.jpg",
                                        "https://www.youtube.com/watch?v=jQ5lPt9edzQ",
                                        3 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Blade Runner",
                                        "Blade Runner: En un futuro distópico, un detective caza androides rebeldes que parecen humanos en una ciudad lluviosa. Reflexiona sobre humanidad y tecnología. " ,
                                        "https://pics.filmaffinity.com/blade_runner-351607743-large.jpg",
                                        "https://www.youtube.com/watch?v=iYhJ7Mf2Oxs",
                                        3 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Scary Movie",
                                        "Scary Movie: Una parodia hilarante de películas de terror, donde un grupo de amigos enfrenta situaciones cómicas y absurdas mientras se burla de los clichés del género." ,
                                        "https://pics.filmaffinity.com/scary_movie-943532513-large.jpg",
                                        "https://www.youtube.com/watch?v=HTLPULt0eJ4",
                                        4 });


            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Scary Movie",
                                        "Scary Movie: Una parodia hilarante de películas de terror, donde un grupo de amigos enfrenta situaciones cómicas y absurdas mientras se burla de los clichés del género." ,
                                        "https://pics.filmaffinity.com/white_chicks-209366455-large.jpg",
                                        "https://www.youtube.com/watch?v=aeVkbNka9HM",
                                        4 });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Zeigeist",
                                        "Zeitgeist: Documental controvertido que explora teorías sobre religión, finanzas y políticas globales, cuestionando la verdad detrás de eventos históricos y la sociedad moderna." ,
                                        "https://pics.filmaffinity.com/zeitgeist_the_movie-211841070-large.jpg",
                                        "https://www.youtube.com/watch?v=741WH71D34Y",
                                        5 });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Super Size Me ",
                                        "Super Size Me: Un cineasta se somete a un experimento, comiendo solo comida rápida de McDonald's durante 30 días, revelando impactantes efectos en su salud y destacando problemas de la industria alimentaria." ,
                                        "https://pics.filmaffinity.com/super_size_me-712955185-large.jpg",
                                        "https://www.youtube.com/watch?v=as2zMlxeOkw",
                                        5 });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "The Whale",
                                        "The Whale: Un dramaturgo con obesidad mórbida busca la reconciliación con su hija distante antes de su muerte, explorando temas de redención, perdón y la lucha contra los demonios internos." ,
                                        "https://pics.filmaffinity.com/the_whale-293958603-large.jpg",
                                        "https://www.youtube.com/watch?v=nWiQodhMvz4",
                                        6 });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "The Whale",
                                        "The Whale: Un dramaturgo con obesidad mórbida busca la reconciliación con su hija distante antes de su muerte, explorando temas de redención, perdón y la lucha contra los demonios internos." ,
                                        "https://pics.filmaffinity.com/the_whale-293958603-large.jpg",
                                        "https://www.youtube.com/watch?v=nWiQodhMvz4",
                                        6 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Laberinto",
                                        "Dirigida por Jim Henson y protagonizada por David Bowie y Jennifer Connelly, esta película sigue a una joven que debe rescatar a su hermano de un laberinto mágico." ,
                                        "https://pics.filmaffinity.com/labyrinth-472366839-large.jpg",
                                        "https://www.youtube.com/watch?v=-9vcQW_48D4",
                                        7 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "El Viaje de Chihiro",
                                        "Una película de Studio Ghibli dirigida por Hayao Miyazaki, que sigue las peripecias de una niña en un mundo espiritual lleno de seres mágicos." ,
                                        "https://pics.filmaffinity.com/sen_to_chihiro_no_kamikakushi-348587850-large.jpg",
                                        "https://www.youtube.com/watch?v=ByXuk9QqQkk",
                                        7 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "La La Land",
                                        "Dirigida por Damien Chazelle, esta película moderna rinde homenaje a los musicales clásicos mientras narra la historia de amor entre un músico de jazz y una actriz en Los Ángeles." ,
                                        "https://pics.filmaffinity.com/la_la_land-262021831-large.jpg",
                                        "https://www.youtube.com/watch?v=0pdqf4P9MB8",
                                        8 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Escuela de Rock",
                                        "Un músico sin éxito se hace pasar por maestro de música en una escuela elitista y forma una banda de niños prodigio, desatando el poder del rock en sus vidas mientras se enfrentan a desafíos y descubren su pasión por la música. " ,
                                        "https://pics.filmaffinity.com/school_of_rock-150775640-large.jpg",
                                        "https://www.youtube.com/watch?v=5afGGGsxvEA",
                                        8 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Mystic River",
                                        " Dirigida por Clint Eastwood, esta película explora las consecuencias del abuso infantil y el asesinato en una comunidad de Boston. " ,
                                        "https://pics.filmaffinity.com/mystic_river-976638525-large.jpg",
                                        "https://www.youtube.com/watch?v=ZUPnGySXuv4",
                                        9 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Seven",
                                        " Dirigida por David Fincher, esta película gira en torno a dos detectives que investigan una serie de asesinatos brutales basados en los siete pecados capitales " ,
                                        "https://pics.filmaffinity.com/seven_se7en-734875211-large.jpg",
                                        "https://www.youtube.com/watch?v=vr3UZ-axauU",
                                        9 });
            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "El Resplandor",
                                        "Dirigida por Stanley Kubrick, esta película basada en la novela de Stephen King narra la historia de un hombre que se convierte en cuidador de un hotel aislado y comienza a enloquecer." ,
                                        "https://pics.filmaffinity.com/the_shining-453129380-large.jpg",
                                        "https://www.youtube.com/watch?v=FZQvIJxG9Xs",
                                        10 });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Titulo", "Sinopsis", "Poster", "Trailer", "GeneroId" },
                values: new object[] { "Blair Wich Proyect",
                                        "Una película de found footage que sigue a un grupo de documentalistas mientras investigan la leyenda de una bruja en un bosque " ,
                                        "https://pics.filmaffinity.com/the_blair_witch_project-169732125-large.jpg",
                                        "https://www.youtube.com/watch?v=tRsYzxjLmm0",
                                        10 });

       

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
