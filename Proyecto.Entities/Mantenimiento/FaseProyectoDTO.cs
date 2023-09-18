using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class FaseProyectoDTO
    {
        public int FaseProyectoId { get; set; }
        public string? DescFaseProyecto { get; set; }
        public string? CodigoFaseProyecto { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
