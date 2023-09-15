using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Ipecamar
{
    public partial class ReporteQuejasSugerPServMilitarDTO
    {
        public int ReporteQuejaSugerPServMilitarId { get; set; }
        public string? FechaRegistroQuejaSuger { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoComandanciaDependencia { get; set; }
        public string? CodigoZonaNaval { get; set; }
        public string? CodigoTipoNovedad { get; set; }
        public string? SituacionPersonalQuejasSuger { get; set; }
        public string? CategoriaQuejasSuger { get; set; }
        public string? AccionTomadaQuejasSuger { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescComandanciaDependencia { get; set; }
        public string? DescZonaNaval { get; set; }
        public string? DescTipoNovedad { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
