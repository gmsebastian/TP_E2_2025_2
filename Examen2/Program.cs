ServicioMusica servicioMusica = new ServicioMusica();

servicioMusica.Gestor.AgregarCancion(new Cancion("APT", "ROSE", 174));
servicioMusica.Gestor.AgregarCancion(new Cancion("Til Now", "potsu", 126));
servicioMusica.Gestor.AgregarCancion(new Cancion("Timido", "Flans", 192));
servicioMusica.Gestor.AgregarCancion(new Cancion("Llorar", "Los Socios del Ritmo", 223));
servicioMusica.Gestor.AgregarCancion(new Cancion("Meet Me Halfway", "Black Eyed Peas", 290));
servicioMusica.Gestor.AgregarCancion(new Cancion("Himno a Veracruz", "Francisco Morosini Cordero", 144));
servicioMusica.Gestor.AgregarCancion(new Cancion("Un Osito de Peluche de Taiwan", "Los Autenticos Decadentes", 247));
servicioMusica.Gestor.AgregarCancion(new Cancion("As The World Falls Down", "David Bowie", 290));

/*
Console.WriteLine("Ingrese un nombre de usuario:");
string nombreUsuario = Console.ReadLine() ?? "";
Usuario usuario = servicioMusica.RegistrarUsuario(nombreUsuario);

Console.WriteLine("Ingrese el nombre de la playlist");
string nombrePlaylist = Console.ReadLine() ?? "";
usuario.CrearListaReproduccion(nombrePlaylist);
*/


Console.WriteLine("Bienvenido al Sistema de Musica Simple\n");

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("--- REGISTRO DE USUARIO ---");
Console.ResetColor();

Console.Write("Por favor, ingrese su nombre de usuario: ");
string nombreUsuario = Console.ReadLine() ?? "";
Usuario usuario = servicioMusica.RegistrarUsuario(nombreUsuario);

Console.WriteLine($"\n¡Bienvenido, {usuario.Nombre}\n");

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("--- CREACIÓN DE LISTA DE REPRODUCCIÓN ---");
Console.ResetColor();

Console.Write("Ingrese un nombre para su primera lista de reproducción: ");
string PlaylistActual = Console.ReadLine() ?? "";
usuario.CrearListaReproduccion(PlaylistActual);


bool continuar = true;
do
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("\n--- MENU PRINCIPAL ---");
    Console.ResetColor();

    Console.Write("Usuario actual: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(usuario.Nombre);
    Console.ResetColor();

    //Console.WriteLine($"Lista actual: {PlaylistActual} ({usuario.ListasReproduccion[PlaylistActual].Count} canciones)");

    Console.Write("Lista actual: ");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write(PlaylistActual);
    Console.ResetColor();
    Console.WriteLine($" ({usuario.ListasReproduccion[PlaylistActual].Count} canciones)");

    Console.WriteLine("1. Buscar canciones para agregar a la lista");
    Console.WriteLine("2. Ver mi lista de reproduccion (ordenada por duracion)");
    Console.WriteLine("3. Ver todas las canones disponibles");
    Console.WriteLine("4. Crear nueva lista de reproduccion");
    Console.WriteLine("5. Cambiar de lista actual");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    int opcion = 0;
    if (int.TryParse(Console.ReadLine(), out opcion) == false)
    {
        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
        continue;
    }

    Console.Write("\n");

    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese el nombre de la cancion: ");
            string nombreCancion = Console.ReadLine() ?? "";
            usuario.AgregarCancionALista(PlaylistActual, servicioMusica.Gestor.BuscarPorNombre(nombreCancion)[0]);
            break;
        case 2:
            servicioMusica.Gestor.QuickSort(usuario.ListasReproduccion[PlaylistActual], 0, usuario.ListasReproduccion[PlaylistActual].Count - 1);
            usuario.MostrarListasReproduccion();
            servicioMusica.Gestor.CalcularDuracionTotal(usuario.ListasReproduccion[PlaylistActual]);
            break;
        case 3:
            servicioMusica.Gestor.MostrarCancionesDisponibles();
            break;
        case 4:
            Console.Write("Ingrese el nombre de la nueva lista de reproduccion: ");
            string nuevaLista = Console.ReadLine() ?? "";
            usuario.CrearListaReproduccion(nuevaLista);
            break;
        case 5:
            Console.Write("Ingrese el nombre de la lista a la que desea cambiar: ");
            string nuevaListaActual = Console.ReadLine() ?? "";
            if (usuario.ListasReproduccion.ContainsKey(nuevaListaActual))
            {
                PlaylistActual = nuevaListaActual;
                Console.WriteLine($"Lista actualizada a: {PlaylistActual}");
            }
            else
            {
                Console.WriteLine("La lista no existe.");
            }
            break;
        case 6:
            continuar = false;
            Console.WriteLine("Saliendo del programa...");
            break;
    }

} while (continuar);