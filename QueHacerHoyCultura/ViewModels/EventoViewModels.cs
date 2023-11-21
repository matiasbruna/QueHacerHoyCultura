using QueHacerHoyCultura.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QueHacerHoyCultura.ViewModels
{
    public class EventoViewModels
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Evento")]
        [Required(ErrorMessage = "Ingrese un nombre para el Evento")]
        public string NombreEvento { get; set; } = null!;

        [Display(Name = "Lugar del Evento")]
        [Required(ErrorMessage = "Ingrese un Lugar del Evento")]
        public string Lugar { get; set; } = null!;

        [Display(Name = "Direccion del Evento")]
        [Required(ErrorMessage = "Ingrese una direccion del Evento")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "Fecha y hora del Evento.")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Por favor, ingrese fecha y hora para el Evento.")]
        public DateTime? FechaEvento { get; set; } = null;

        [Display(Name = "Imagen Evento")]
        public IFormFile? Imagen { get; set; }

        [Display(Name = "Imagen")]
        public string? ImagenEvento{ get; set; }


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
