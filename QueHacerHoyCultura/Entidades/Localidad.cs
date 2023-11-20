namespace QueHacerHoyCultura.Entidades
{
    public class Localidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public int ProvinciaId { get; set; }

        public Provincia Provincia { get; set; } = null!;

        public List<Usuario> Usuario { get; set; } =  new List<Usuario>();
    }
}
