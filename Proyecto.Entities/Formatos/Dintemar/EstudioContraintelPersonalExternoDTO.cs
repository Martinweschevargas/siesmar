using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dintemar
{
    public partial class EstudioContraintelPersonalExternoDTO
    {
        public int EstudioContrainteligenciaPersonalExternoId { get; set; }
        public string? NumericoPais { get; set; }
        public string? CodigoTipoVinculo { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public int? InvestigacionContrainteligenciaProducida { get; set; }
        public string? CodigoTipoEstudioContrainteligencia { get; set; }


        public string? NombrePais { get; set; }
        public string? DescTipoVinculo { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? DescTipoEstudioContrainteligencia { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
