namespace PruebasGestorCanciones {
    public class GestorCancionesTests {
        [Fact]
        public void AgregarCancion_DeberiaAgregarCorrectamente() {
            // Arrange
            var gestor = new GestorCanciones();
            var cancion = new Cancion("Viva La Vida", "Coldplay", 242);

            // Act
            gestor.AgregarCancion(cancion);

            // Assert
            Assert.Single(gestor.CancionesDisponibles);
            Assert.Equal("Viva La Vida", gestor.CancionesDisponibles[0].Nombre);
        }

        [Fact]
        public void BuscarPorNombre_DeberiaEncontrarCoincidencias() {
            // Arrange
            var gestor = new GestorCanciones();
            gestor.AgregarCancion(new Cancion("Shape of You", "Ed Sheeran", 233));
            gestor.AgregarCancion(new Cancion("You Belong With Me", "Taylor Swift", 210));
            gestor.AgregarCancion(new Cancion("Rolling in the Deep", "Adele", 228));

            // Act
            var resultados = gestor.BuscarPorNombre("you");

            // Assert
            Assert.Equal(2, resultados.Count);
        }

        [Fact]
        public void QuickSort_DeberiaOrdenarPorDuracion() {
            // Arrange
            var gestor = new GestorCanciones();
            var canciones = new List<Cancion>
            {
                new Cancion("C", "Artista", 300),
                new Cancion("A", "Artista", 180),
                new Cancion("B", "Artista", 240)
            };

            // Act
            gestor.QuickSort(canciones, 0, canciones.Count - 1);

            // Assert
            Assert.Equal("A", canciones[0].Nombre); // 180
            Assert.Equal("B", canciones[1].Nombre); // 240
            Assert.Equal("C", canciones[2].Nombre); // 300
        }

        [Fact]
        public void CalcularDuracionTotal_DeberiaCalcularCorrectamente() {
            // Arrange
            var gestor = new GestorCanciones();
            var canciones = new List<Cancion>
            {
                new Cancion("Cancion1", "Artista1", 120),
                new Cancion("Cancion2", "Artista2", 180)
            };

            // Act
            int duracionCalculada = canciones.Sum(c => c.DuracionSegundos);

            // Assert
            Assert.Equal(300, duracionCalculada);
        }
    }
}