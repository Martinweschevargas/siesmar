using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dintemar
{
    public partial class EstudioContrainteligenciaPersonaNavalDTO :  DintemarBaseDto
    {
        public int EstudioContrainteligenciaPersonaNavalId { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public int? EstudioContrainteligenciaProducida { get; set; }
        public string? CodigoTipoEstudioContrainteligencia { get; set; }



        public string? DescDependencia { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescTipoContrainteligencia { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
