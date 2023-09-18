using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dintemar
{
    public partial class ProduccionDocumentosContraintelDTO
    {
        public int ProduccionDocumentosContrainteligenciaId { get; set; }
        public int? MesId { get; set; }
        public int? AnioProduccionDocumento { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public int? NotasInformacionContrainteligencia { get; set; }
        public int? NotasContrainteligenciaProducidas { get; set; }
        public int? ApreciacionesContrainteligenciaProducida { get; set; }


        public string? DescMes { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public int? CargaId { get; set; }
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
