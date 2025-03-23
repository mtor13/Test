namespace ApiTest.ViewModel
{
    public class ActividadesViewModel
    {
        public int IdActividad { get; set; }

        public DateTime CreateDate { get; set; }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }

        public string Actividad { get; set; } = null!;
    }
}
