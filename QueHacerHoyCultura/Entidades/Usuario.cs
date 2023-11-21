using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueHacerHoyCultura.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por Favor, Ingrese un Nombre")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Por Favor, Ingrese un Email")]
        public string Email { get; set; } = null!;

        [Display(Name = "Localidad" )]
        public int LocalidadId{ get; set; }
        [ForeignKey("LocalidadId")]
        public Localidad? Localidad { get; set; } = null!;

        [Display(Name = "Tipo de Usuario")]
        public int TipoUsuarioId { get; set; }
        [ForeignKey("TipoUsuarioId")]
        public TipoUsuario? TipoUsuario { get; set; } = null!;
    }
}
