using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirconce
{
    public partial class RecaudacionMensualContratoDTO
    {

        public int? RecaudacionMensualContratoId { get; set; }
        public decimal? RecaudacionEconomicaMensual { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
