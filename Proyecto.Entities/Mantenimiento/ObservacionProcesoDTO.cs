using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ObservacionProcesoDTO
    {
        public int ObservacionProcesoId { get; set; }
        public string? DescObservacionProceso { get; set; }
        public string? CodigoObservacionProceso { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
