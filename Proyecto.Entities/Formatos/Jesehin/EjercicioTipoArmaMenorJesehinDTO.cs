using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Jesehin
{
    public partial class EjercicioTipoArmaMenorJesehinDTO
    {

        public int? EjercicioTipoArmaMenorJesehinId { get; set; }
        public int? TipoPersonalMilitarId { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public string? FechaEjercicioTipo { get; set; }
        public int? TipoArmamentoId { get; set; }
        public int? PosicionTipoArmaId { get; set; }
        public decimal? DistanciaMetros { get; set; }
        public int? CantidadTiro { get; set; }


        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGrado { get; set; }
        public string? DescTipoArmamento { get; set; }
        public string? DescPosicionTipoArma { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}