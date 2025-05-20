namespace PruebasUsuario {
    public class UsuarioTests {
        [Fact]
        public void CrearListaReproduccion_DeberiaAgregarListaNueva() {
            // Arrange
            var usuario = new Usuario("Ana");

            // Act
            usuario.CrearListaReproduccion("Favoritas");

            // Assert
            Assert.True(usuario.ListasReproduccion.ContainsKey("Favoritas"));
            Assert.Empty(usuario.ListasReproduccion["Favoritas"]);
        }

        [Fact]
        public void CrearListaReproduccion_NoDeberiaDuplicarLista() {
            // Arrange
            var usuario = new Usuario("Luis");
            usuario.CrearListaReproduccion("Workout");

            // Act
            usuario.CrearListaReproduccion("Workout");

            // Assert
            Assert.Single(usuario.ListasReproduccion); // Solo debe haber una lista
        }

        [Fact]
        public void AgregarCancionALista_DeberiaAgregarCorrectamente() {
            // Arrange
            var usuario = new Usuario("Carlos");
            usuario.CrearListaReproduccion("Relax");
            var cancion = new Cancion("Let It Be", "The Beatles", 243);

            // Act
            usuario.AgregarCancionALista("Relax", cancion);

            // Assert
            var lista = usuario.ListasReproduccion["Relax"];
            Assert.Single(lista);
            Assert.Equal("Let It Be", lista[0].Nombre);
            Assert.Equal("The Beatles", lista[0].Artista);
        }

        [Fact]
        public void AgregarCancionALista_NoDebeAgregarSiListaNoExiste() {
            // Arrange
            var usuario = new Usuario("Marta");
            var cancion = new Cancion("Chiquitita", "ABBA", 312);

            // Act
            usuario.AgregarCancionALista("Pop", cancion);

            // Assert
            Assert.False(usuario.ListasReproduccion.ContainsKey("Pop")); // No se debe haber creado la lista
        }
    }
}
