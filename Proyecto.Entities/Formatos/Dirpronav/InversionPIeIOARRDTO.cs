using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirpronav
{
    public partial class InversionPIeIOARRDTO
    {
        public int InversionPIeIOARRId { get; set; }
        public int? CodigoUnificado { get; set; }
        public string? NombreInversion { get; set; }
        public string? CodigoClaseInversion { get; set; }
        public decimal? MontoInversionInicial { get; set; }
        public decimal? MontoInversionModificado { get; set; }
        public string? FechaViabilidadProyecto { get; set; }
        public string? CodigoFaseInversion { get; set; }
        public string? UnidadFormuladora { get; set; }
        public string? UnidadEjecutora { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoEstadoFase1FormEval { get; set; }
        public string? CodigoEstadoFase2Ejecucion { get; set; }
        public string? CodigoEstadoFase3Funcionamiento { get; set; }
        public string? CodigoFuenteFinanciamiento { get; set; }
        public string? FechaTerminoEjecucionInversion { get; set; }
        public string? FechaUltimaActualizacionProyecto { get; set; } 
        public int? CargaId { get; set; } 


        public string? DescClaseInversion { get; set; }
        public string? DescFaseInversion { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescEstadoFase1FormEval { get; set; }
        public string? DescEstadoFase2Ejecucion { get; set; }
        public string? DescEstadoFase3Funcionamiento { get; set; }
        public string? DescFuenteFinanciamiento { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
