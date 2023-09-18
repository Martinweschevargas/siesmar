using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class TransmisionProgramaRadialDTO
    {

        public int? TransmisionProgramaRadialId { get; set; }
        public string? FechaTransmision { get; set; }
        public string? CodigoTipoInformacionEmitida { get; set; }
        public string? CodigoPublicoObjetivo { get; set; }
        public int? Reproducciones { get; set; }
        public int? Oyentes { get; set; }

        public string? DescTipoInformacionEmitida { get; set; }
        public string? DescPublicoObjetivo { get; set; }

        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
