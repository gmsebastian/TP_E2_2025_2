namespace PruebasServicioMusica {
    public class ServicioMusicaTests {
        [Fact]
        public void RegistrarUsuario_DeberiaAgregarUsuarioCorrectamente() {
            // Arrange
            var servicio = new ServicioMusica();

            // Act
            var usuario = servicio.RegistrarUsuario("Laura");

            // Assert
            Assert.Single(servicio.Usuarios);
            Assert.Equal("Laura", usuario.Nombre);
        }

        [Fact]
        public void RegistrarUsuario_MultiplesUsuariosDeberianRegistrarse() {
            // Arrange
            var servicio = new ServicioMusica();

            // Act
            servicio.RegistrarUsuario("Carlos");
            servicio.RegistrarUsuario("Ana");

            // Assert
            Assert.Equal(2, servicio.Usuarios.Count);
            Assert.Contains(servicio.Usuarios, u => u.Nombre == "Ana");
        }

        [Fact]
        public void BuscarUsuario_DeberiaRetornarUsuarioSiExiste() {
            // Arrange
            var servicio = new ServicioMusica();
            servicio.RegistrarUsuario("Marta");

            // Act
            var encontrado = servicio.BuscarUsuario("marta");

            // Assert
            Assert.NotNull(encontrado);
            Assert.Equal("Marta", encontrado.Nombre);
        }

        [Fact]
        public void BuscarUsuario_DeberiaRetornarNullSiNoExiste() {
            // Arrange
            var servicio = new ServicioMusica();
            servicio.RegistrarUsuario("Juan");

            // Act
            var resultado = servicio.BuscarUsuario("Pedro");

            // Assert
            Assert.Null(resultado);
        }
    }
}