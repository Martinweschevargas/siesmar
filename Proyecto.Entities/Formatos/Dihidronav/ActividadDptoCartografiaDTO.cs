using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dihidronav
{
    public partial class ActividadDptoCartografiaDTO
    {

        public int? ActividadDptoCartografiaId { get; set; }
        public int? NumeroOrden { get; set; }
        public string? Requerimiento { get; set; }
        public string? CodigoTipoCarta { get; set; }
        public string? Proceso { get; set; }
        public string? Clasificacion { get; set; }
        public string? CodigoNombre { get; set; }
        public string? Edicion { get; set; }
        public int? Escala { get; set; }
        public int? SituacionPorcentaje { get; set; }
        public string? FechaAutorizacionProduccion { get; set; }
        public string? FechaTerminoCarta { get; set; }
        public string? DescTipoCarta { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}