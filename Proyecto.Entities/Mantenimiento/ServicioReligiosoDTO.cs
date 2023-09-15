using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ServicioReligiosoDTO
    {
        public int ServicioReligiosoId { get; set; }
        public string? DescServicioReligioso { get; set; }
        public string? CodigoServicioReligioso { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
