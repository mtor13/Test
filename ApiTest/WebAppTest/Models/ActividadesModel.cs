namespace WebAppTest.Models
{
    public class ActividadesModel
    {
        public int IdActividad { get; set; }

        public DateOnly CreateDate { get; set; }

        public int IdUsuario { get; set; }

        public string Actividad { get; set; } = null!;
    }
}
