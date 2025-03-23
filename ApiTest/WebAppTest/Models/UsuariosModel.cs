namespace WebAppTest.Models
{
    public class UsuariosModel
    {
        public int? IdUsuario { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string CorreoElectronico { get; set; } = null!;

        public DateOnly FechaNacimiento { get; set; }

        public int? Telefono { get; set; }

        public string PaisResidencia { get; set; } = null!;

        public bool Contacto { get; set; }
    }
}
