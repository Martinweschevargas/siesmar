using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzouno
{
    public partial class EjercicioTipoArmaMenorComzounoDTO
    {

        public int EjercicioTipoArmaMenorComzounoId { get; set; }
        public string? CodigoTipoPersonalMilitar { get; set; }
        public string? CodigoGradoPersonalMilitar { get; set; }
        public string? FechaEjercicioTipo { get; set; }
        public string? CodigoTipoArmamento { get; set; }
        public string? CodigoPosicionTipoArma { get; set; }
        public decimal? DistanciaMetros { get; set; }
        public int? CantidadTiro { get; set; }


        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescTipoArmamento { get; set; }
        public string? DescPosicionTipoArma { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}