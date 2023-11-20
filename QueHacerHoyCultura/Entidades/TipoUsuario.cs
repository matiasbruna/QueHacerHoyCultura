namespace QueHacerHoyCultura.Entidades
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public List<Usuario> Usuario { get; set; } = new List<Usuario>();
        
    }
}
