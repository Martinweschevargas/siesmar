using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SituacionOperatividadEquipoDTO
    {
        public int SituacionOperatividadEquipoId { get; set; }
        public string? DescripcionMaterial { get; set; }
        public string? Cantidad { get; set; }
        public string? CodigoUnidad { get; set; }
        public string? Ubicacion { get; set; }
        public string? Distrito { get; set; }
        public string? Condicion { get; set; }
        public string? Observacion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
