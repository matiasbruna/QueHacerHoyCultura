using System.ComponentModel.DataAnnotations;

namespace QueHacerHoyCultura.Entidades
{
    public class TipoEvento
    {
        public int Id { get; set; }

        [Display(Name = "Tipos de Evento")]
        public string Nombre { get; set; } = null!;
        
        public List<Eventos> Eventos { get; set; } = new List<Eventos>();
    }
}
