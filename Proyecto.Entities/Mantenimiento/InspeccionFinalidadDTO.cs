using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class InspeccionFinalidadDTO
    {
        public int InspeccionFinalidadId { get; set; }
        public string? DescInspeccionFinalidad { get; set; }
        public string? CodigoInspeccionFinalidad { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
