
using Domain.Entities;
using Infrastructure.Conexion;
using PSCineGBA.Controller;




    public partial class Program
{
    static void Main(string[] args)
    {

        var context = new CineDbContext();
        var funcionService = new FuncionService(context);
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("************");
                Console.WriteLine(" Cine GBA");
                Console.WriteLine("************");
                Console.WriteLine(" ");
                Console.WriteLine(" Menú de Opciones ");
                Console.WriteLine(" -----------------");
                Console.WriteLine(" ");
                Console.WriteLine(" 1. Nueva Funcion ");
                Console.WriteLine(" 2. Funciones por pelicula ");
                Console.WriteLine(" 3. Funciones por dia ");
                Console.WriteLine(" 4. Salir ");
                Console.WriteLine(" ");
                Console.WriteLine("******************************");
                Console.Write("Ingrese  una opción: ");

                char option = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                switch (option)
                {   

                    case '1':
                        
                        var nuevaFuncion = new Funcion();

                        Console.Write("Fecha (YYYY-MM-DD): ");
                        DateTime fecha;
                        while (true)
                        {
                            try
                            {  
                                if (DateTime.TryParse(Console.ReadLine(), out fecha))
                                    break;
                                else
                                    throw new Exception("Formato incorrecto. Utilice el formato YYYY-MM-DD.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        nuevaFuncion.Fecha = fecha;

                        Console.Write("Horario (HH:mm:ss): ");
                        DateTime horario;
                        while (true)
                        {
                            try
                            {
                                if (DateTime.TryParse(Console.ReadLine(), out horario))
                                    break;
                                else
                                    throw new Exception("Horario no válido. Ingrese un horario en el formato HH:mm:ss.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        nuevaFuncion.Horario = horario;

                        // Listar peliculas disponibles
                        var todaslaspeliculas = funcionService.GetAllPeliculas();
                        Console.WriteLine("Peliculas disponibles:");
                        foreach (var pelicula in todaslaspeliculas)
                        {
                            Console.WriteLine($"ID: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
                        }

                        int peliculaId;
                        while (true)
                        {
                            try
                            {
                                Console.Write("Seleccione la película (ID): ");
                                if (int.TryParse(Console.ReadLine(), out peliculaId))
                                {
                                    if (todaslaspeliculas.Any(p => p.PeliculaId == peliculaId))
                                        break;
                                    else
                                        throw new Exception("ID de película no válido. Seleccione un ID válido.");
                                }
                                else
                                {
                                    throw new Exception("ID de película no válido. Ingrese un número.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        nuevaFuncion.PeliculaId = peliculaId;

                        // salas disponibles
                        var salas = funcionService.GetAllSalas();
                        Console.WriteLine("Salas disponibles:");
                        foreach (var sala in salas)
                        {
                            Console.WriteLine($"ID: {sala.SalaId}, Nombre: {sala.Nombre}");
                        }

                        int salaId;
                        while (true)
                        {
                            Console.Write("Seleccione la sala (ID): ");
                            if (int.TryParse(Console.ReadLine(), out salaId))
                            {
                                if (salas.Any(s => s.SalaId == salaId))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("ID de sala no válido. Seleccione un ID válido.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID de sala no válido. Ingrese un número.");
                            }
                        }
                        nuevaFuncion.SalaId = salaId;

                        // Se muestra un resumen de los campos seleccionados por el operador antes de confirmar el alta
                        Console.WriteLine();
                        Console.WriteLine("Datos de la nueva función:");
                        Console.WriteLine($"Fecha: {nuevaFuncion.Fecha.ToString("yyyy-MM-dd")}, Horario: {nuevaFuncion.Horario.ToString("HH:mm:ss")}");
                        string peliculaTitulo = funcionService.GetPeliculaTituloById(nuevaFuncion.PeliculaId);
                        string salaNombre = funcionService.GetSalaNombreById(nuevaFuncion.SalaId);
                        string generoNombre = funcionService.GetGeneroNombreById(nuevaFuncion.PeliculaId);
                        Console.WriteLine($"Película: {peliculaTitulo}");
                        Console.WriteLine($"Genero: {generoNombre} ");
                        Console.WriteLine($"Sala: {salaNombre}");

                        funcionService.CreateFuncion(nuevaFuncion);
                        Console.WriteLine(" ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Función registrada.");
                        Console.WriteLine("Presione cualquier tecla para volver al menú principal");
                        Console.ReadKey();




                        break;

                    case '2':

                        Console.WriteLine("Buscador de funciones por película: ");

                        // Traer todas las películas disponibles
                        var peliculas = funcionService.GetAllPeliculas();

                        if (peliculas.Any())
                        {
                            Console.WriteLine("Funciones para la pelicula:");
                            foreach (var pelicula in peliculas)
                            {
                                Console.WriteLine($"ID: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
                            }

                            int seleccion;
                            while (true)
                            {
                                try
                                {
                                    Console.Write("Seleccione la película: ");
                                    if (int.TryParse(Console.ReadLine(), out seleccion))
                                    {
                                        if (peliculas.Any(p => p.PeliculaId == seleccion))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ID invalido.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("ID invalido");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }

                            //  Mostrar las funciones para la película seleccionada
                            var funcionesPorPelicula = funcionService.GetFuncionesPorPelicula(seleccion);

                            if (funcionesPorPelicula.Any())
                            {

                                Console.WriteLine($"Funciones para la película (ID: {seleccion}):");

                                foreach (var funcion in funcionesPorPelicula)
                                {
                                    Console.WriteLine($"Funcion N°: {funcion.FuncionId}, Fecha: {funcion.Fecha.ToString("yyyy-MM-dd")}, Hora: {funcion.Horario.ToString("HH:mm:ss")}");
                                    string nombredelasala = funcionService.GetSalaNombreById(funcion.SalaId);
                                    string nombredelgenero = funcionService.GetGeneroNombreById(funcion.PeliculaId);
                                    string nombredelapelicula = funcionService.GetPeliculaTituloById(funcion.PeliculaId);
                                    Console.WriteLine($"Sala: {nombredelasala} ");
                                    Console.WriteLine($"Película: {nombredelapelicula} ");
                                    Console.WriteLine($"Genero: {nombredelgenero}");
                                }
                            }
                            else
                            {
                                Console.WriteLine(" Película seleccionada sin funciones activas.");
                            }

                            Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("No hay películas disponibles.");
                            Console.WriteLine("Presione cualquier tecla para volver al menú principal");
                            Console.ReadKey();
                        }

                        break;


                    case '3':
                        // Listar funciones por día y/o título de película
                        Console.WriteLine("Bienvenido al buscador de funciones");
                        Console.Write("Ingrese la fecha (YYYY-MM-DD): ");
                        string fechaStr = Console.ReadLine();
                        DateTime? fechaFiltro = null;

                        if (!string.IsNullOrEmpty(fechaStr) && DateTime.TryParse(fechaStr, out DateTime fechaSeleccionada))
                        {
                            fechaFiltro = fechaSeleccionada;
                        }

                        if (fechaFiltro.HasValue)
                        {
                            var funcionesFiltradas = funcionService.GetFuncionesPorFecha(fechaFiltro.Value);

                            if (funcionesFiltradas.Any())
                            {
                                foreach (var funcion in funcionesFiltradas)
                                {
                                    Console.WriteLine("--------------------------------------------");
                                    Console.WriteLine($"Funcion N°: {funcion.FuncionId}, Fecha: {funcion.Fecha.ToString("yyyy-MM-dd")}, Hora: {funcion.Horario.ToString("HH:mm:ss")}");
                                    Console.WriteLine($"Pelicula: {funcion.Peliculas.Titulo}, Sala: {funcion.Salas.Nombre}");
                                    string nombredelasala = funcionService.GetSalaNombreById(funcion.SalaId);
                                    string nombredelgenero = funcionService.GetGeneroNombreById(funcion.PeliculaId);
                                    string nombredelapelicula = funcionService.GetPeliculaTituloById(funcion.PeliculaId);
                                    Console.WriteLine($"{nombredelasala}, Película: {nombredelapelicula}, Genero: {nombredelgenero}");
                                    Console.WriteLine("--------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Fecha seleccionada sin funciones activas.");
                            }

                            Console.WriteLine("Presione cualquier tecla para volver al menú principal");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Fecha no válida.");
                        }

                        break;

                    case '4':
                        return;

                }
                
            }
        }
    }
}


