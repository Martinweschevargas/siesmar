using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Direcomar
{
    public partial class EvaluacionPresupuestalDTO
    {

        public int? EvaluacionPresupuestalId { get; set; }
        public int? AnioEvaluacionPresupuesta { get; set; }
        public string? NumeroMes { get; set; }
        public string? CodigoSubunidadEjecutora { get; set; }
        public string? CodigoFuenteFinanciamiento { get; set; }
        public string? ClasificacionGenericaGasto { get; set; }
        public decimal? ASIGPIMPresupuestal { get; set; }
        public decimal? PCAPresupuestal { get; set; }
        public decimal? CertificadoPresupuestal { get; set; }
        public decimal? CompromisoPresupuestal { get; set; }
        public decimal? DevengadoPresupuestal { get; set; }
        public decimal? GiradoPresupuestal { get; set; }
        public int? AvancePresupuestal { get; set; }


        public string? DescMes { get; set; }
        public string? DescClasificacionGenericaGasto { get; set; }
        
        public string? DescSubUnidadEjecutora { get; set; }
        public string? DescFuenteFinanciamiento { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
