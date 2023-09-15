using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class RevistaInstitucionalMonitorGrumeteDTO
    {

        public int? RevistaInstitucionalMonitorGrumeteId { get; set; }
        public string? CodigoProductoDimar { get; set; }
        public string? CodigoFrecuenciaDifusion { get; set; }
        public string? FechaPublicacion { get; set; }
        public int? NroEdicion { get; set; }
        public string? CodigoTipoInformacionEmitida { get; set; }
        public string? CodigoPlataformaMedioComunicacion { get; set; }
        public string? CodigoPublicoObjetivo { get; set; }
        public int? CantidadProducida { get; set; }


        public string? DescProductoDimar { get; set; }
        public string? DescFrecuenciaDifusion { get; set; }
        public string? DescTipoInformacionEmitida { get; set; }
        public string? DescPlataformaMedioComunicacion { get; set; }
        public string? DescPublicoObjetivo { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
