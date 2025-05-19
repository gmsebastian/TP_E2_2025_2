public class ServicioMusica
{
    // Propiedades
    public GestorCanciones Gestor;
    public List<Usuario> Usuarios;

    // Constructor
    public ServicioMusica()
    {
        Gestor = new GestorCanciones();
        Usuarios = new List<Usuario>();
    }

    // Métodos
    public Usuario RegistrarUsuario(string nombre)
    {
        Usuario nuevoUsuario = new Usuario(nombre);
        try
        {
            Usuarios.Add(nuevoUsuario);
            Console.WriteLine($"Usuario '{nombre}' registrado con éxito.");
            return nuevoUsuario;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            return null;
        }
    }
    public Usuario BuscarUsuario(string nombre)
    {
        return Usuarios.FirstOrDefault(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }
}