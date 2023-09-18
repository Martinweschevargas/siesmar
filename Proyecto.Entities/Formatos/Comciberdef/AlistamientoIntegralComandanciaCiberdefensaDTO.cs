using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comciberdef
{
    public partial class AlistamientoIntegralComandanciaCiberdefensaDTO
    {

        public int? AlistamientoIntegralCiberdefensaId { get; set; }
        public int? AnioAlistamiento { get; set; }
        public string? SemestreAlistamiento { get; set; }
        public decimal? AlistamientoPersonal { get; set; }
        public decimal? AlistamientoEntretenimiento { get; set; }
        public decimal? AlistamientoMaterial { get; set; }
        public decimal? AlistamientoLogistico { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
