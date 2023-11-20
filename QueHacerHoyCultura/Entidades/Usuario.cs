namespace QueHacerHoyCultura.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int Localidad { get; set; }

        public int IdTipoUsuario { get; set; }
    }
}
