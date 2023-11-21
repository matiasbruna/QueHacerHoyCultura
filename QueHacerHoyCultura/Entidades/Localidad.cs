using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueHacerHoyCultura.Entidades
{
    public class Localidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        [Display(Name = "Provincia")]
        public int ProvinciaId { get; set; }

        [ForeignKey("ProvinciaId")]
        public Provincia? Provincia { get; set; } = null!;

        public List<Usuario> Usuario { get; set; } =  new List<Usuario>();

        public List<Eventos> Eventos { get; set; } = new List<Eventos>();
    }
}
