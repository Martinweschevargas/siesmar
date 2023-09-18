using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ActClimaLaboralGeneralDTO
    {
        public int ActClimaLaboralGeneralId { get; set; }
        public string? DescActClimaLaboralGeneral { get; set; }
        public string? CodigoActClimaLaboralGeneral { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
