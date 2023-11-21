using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueHacerHoyCultura.Entidades
{
    public class Eventos
    {
        public int Id { get; set; }

        [Display (Name = "Nombre del Evento")]
        [Required(ErrorMessage ="Ingrese un nombre para el Evento")]
        public string NombreEvento { get; set; } = null!;

        [Display (Name = "Lugar del Evento")]
        [Required(ErrorMessage = "Ingrese un Lugar del Evento")]
        public string Lugar { get; set; } = null!;

        [Display(Name = "Direccion del Evento")]
        [Required(ErrorMessage = "Ingrese una direccion del Evento")]
        public string Direccion { get; set; } = null!;

        [Display (Name = "Fecha y hora del Evento.")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Por favor, ingrese fecha y hora para el Evento.")]
        public DateTime? FechaEvento { get; set; } = null;

        [Display (Name = "Imagen Baner")]
        public byte[] Imagen { get; set; } = null!; 
        public string NombreArchivo { get; set; } = null!;
        public string TipoMIME { get; set; } = null!;

        [Display(Name = "Localidad")]
        public int LocalidadId { get; set; }

        [ForeignKey("LocalidadId")]
        public Localidad? Localidad { get; set; } = null!;

        [Display(Name = "Tipo de Evento")]
        public int TipoEventoId { get; set; }

        [ForeignKey("TipoEventoId")]
        public TipoEvento? TipoEvento { get; set; } = null!;



    }
}
