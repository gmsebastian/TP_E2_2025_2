namespace PruebasCancion {
    public class CancionTests {
        [Fact]
        public void ToString_DeberiaRetornarFormatoCorrecto() {
            // Arrange
            var cancion = new Cancion("Imagine", "John Lennon", 183); // 3 min 3 seg

            // Act
            var resultado = cancion.ToString();

            // Assert
            Assert.Equal("\tImagine - John Lennon (3:03)", resultado);
        }

        [Fact]
        public void Constructor_DeberiaAsignarPropiedadesCorrectamente() {
            // Arrange
            var cancion = new Cancion("Bohemian Rhapsody", "Queen", 354);

            // Assert
            Assert.Equal("Bohemian Rhapsody", cancion.Nombre);
            Assert.Equal("Queen", cancion.Artista);
            Assert.Equal(354, cancion.DuracionSegundos);
        }
    }
}
