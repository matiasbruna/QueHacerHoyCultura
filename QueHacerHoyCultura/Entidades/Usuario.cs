namespace QueHacerHoyCultura.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int LocalidadId{ get; set; }

        public Localidad Localidad { get; set; } = null!;

        public int TipoUsuarioId { get; set; }

        public TipoUsuario TipoUsuario { get; set; } = null!;
    }
}
