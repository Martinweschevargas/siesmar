using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class ComunicadoEmisionMesDTO
    {

        public int? ComunicadoEmisionMesId { get; set; }
        public string? FechaEmisionComunicado { get; set; }
        public int? NumeroComunicados { get; set; }
        public string? CodigoTipoInformacionEmitida { get; set; }
        public string? CodigoPublicoObjetivo { get; set; }


        public string? DescTipoInformacionEmitida { get; set; }
        public string? DescPublicoObjetivo { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
