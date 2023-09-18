using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class NivelEntrenamientoDTO
    {
        public int NivelEntrenamientoId { get; set; }
        public string? DescNivelEntrenamiento { get; set; }
        public string? CodigoNivelEntrenamiento { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
