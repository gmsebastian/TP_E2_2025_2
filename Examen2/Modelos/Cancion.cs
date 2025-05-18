public class Cancion
{
    // Propiedades
    public string Nombre { get; set; }
    public string Artista { get; set; }
    public int DuracionSegundos { get; set; }

    // Constructor
    public Cancion(string nombre, string artista, int duracionSegundos)
    {
        Nombre = nombre;
        Artista = artista;
        DuracionSegundos = duracionSegundos;
    }

    // Métodos
    public override string ToString()
    {
        // Calculo de minutos y segundos
        int minutos = DuracionSegundos / 60;
        int segundos = DuracionSegundos % 60;
        // Devolucion del string
        return ($"{Nombre} - {Artista} ({minutos}:{segundos})");
    }
}