using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Centac
{
    public partial class EntrenamientoRealizadoComandanciaDTO
    {
        public int? EntrenamientoRealizadoComandanciaId { get; set; }
        public string? EventoEntrenamiento { get; set; }
        public string? FechaEvento { get; set; }
        public int? NumeroHoras { get; set; }
        public string? EventoProgramado { get; set; }
        public string? CodigoDependencia { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoTipoOperacion { get; set; }
        public string? NivelEntrenamiento { get; set; }
        public string? CodigoTipoEjercicio { get; set; }
        public int? FcComunicaciones { get; set; }
        public int? FcPosicionInicial { get; set; }
        public int? FcFunciones { get; set; }
        public int? FcAcciones { get; set; }
        public int? FcAtaque { get; set; }
        public int? PorcentajeFinalEvaluacion { get; set; }
        public string? CodigoFormula2CalificativoCentac { get; set; }
        public int? CargaId { get; set; }
        public string? NombreDependencia { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? DescTipoOperacion { get; set; }
        public string? DescTipoEjercicio { get; set; }
        public string? DescFormula2CalificativoCentac { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
