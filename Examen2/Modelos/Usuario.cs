public class Usuario
{
    // Propiedades
    public string Nombre { get; set; }
    public Dictionary<string, List<Cancion>> ListasReproduccion { get; set; }

    // Constructor
    public Usuario(string nombre)
    {
        Nombre = nombre;
        ListasReproduccion = new Dictionary<string, List<Cancion>>();
    }

    // Métodos
    public void CrearListaReproduccion(string nombreLista)
    {
        if (!ListasReproduccion.ContainsKey(nombreLista)) // Verifica si la lista no existe
        {
            ListasReproduccion[nombreLista] = new List<Cancion>();
            Console.WriteLine($"Lista de reproducción '{nombreLista}' creada con éxito.");
        }
        else
        {
            Console.WriteLine("ERROR: La lista de reproducción ya existe.");
        }
    }
    public void AgregarCancionALista(string nombreLista, Cancion cancion)
    {
        if (ListasReproduccion.ContainsKey(nombreLista)) // Verifica si la lista existe
        {
            ListasReproduccion[nombreLista].Add(cancion);
            Console.WriteLine($"Canción '{cancion.Nombre}' agregada a la lista '{nombreLista}'.");
        }
        else
        {
            Console.WriteLine("ERROR: La lista de reproducción no existe.");
        }
    }
    public void MostrarListasReproduccion()
    {
        foreach (var lista in ListasReproduccion)
        {
            Console.WriteLine($"Lista: {lista.Key}");
            foreach (var cancion in lista.Value)
            {
                cancion.ToString(); // Llama al método ToString de la clase Cancion
            }
        }
    }
}