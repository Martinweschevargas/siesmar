using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comciberdef
{
    public partial class CooperacionBilateralMultilateralCiberdefensaDTO
    {

        public int? CooperacionBilateralMultilateralId { get; set; }
        public string? FechaCooperacion { get; set; }
        public string? CodigoTipoAcuerdo { get; set; }
        public string? AsuntoCooperacion { get; set; }
        public string? DescTipoAcuerdo { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
