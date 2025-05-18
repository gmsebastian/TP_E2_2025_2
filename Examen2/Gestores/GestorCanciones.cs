public class GestorCanciones
{
    // Propiedades
    List<Cancion> CancionesDisponibles { get; set; }

    // Constructor
    public GestorCanciones()
    {
        CancionesDisponibles = new List<Cancion>();
    }

    // Métodos
    public void AgregarCancion(Cancion cancion)
    {
        CancionesDisponibles.Add(cancion);
    }
    public List<Cancion> BuscarPorNombre(string nombre)
    {
        return CancionesDisponibles.Where(c => c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
    }


    public void QuickSort(List<Cancion> canciones, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(canciones, low, high);

            QuickSort(canciones, low, pi - 1);
            QuickSort(canciones, pi + 1, high);
        }
    }
    private int Partition(List<Cancion> canciones, int low, int high)
    {
        int pivot = canciones[high].DuracionSegundos;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (canciones[j].DuracionSegundos <= pivot)
            {
                i++;
                (canciones[i], canciones[j]) = (canciones[j], canciones[i]);
            }
        }
        (canciones[i + 1], canciones[high]) = (canciones[high], canciones[i + 1]);
        return i + 1;
    }
}