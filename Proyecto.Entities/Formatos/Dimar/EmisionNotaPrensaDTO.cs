using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dimar
{
    public partial class EmisionNotaPrensaDTO
    {

        public int? EmisionNotaPrensaId { get; set; }
        public string? FechaEmision { get; set; }
        public int? NumeroNotasProducidas { get; set; }
        public string? CodigoTipoInformacionEmitida { get; set; }
        public string? CodigoPlataformaMedioComunicacion { get; set; }
        public string? CodigoPublicoObjetivo { get; set; }


        public string? DescTipoInformacionEmitida { get; set; }
        public string? DescPlataformaMedioComunicacion { get; set; }
        public string? DescPublicoObjetivo { get; set; }

        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
