using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Combasnai
{
    public partial class EjercicioTiroArmaMenorCombasnaiDTO
    {

        public int? EjercicioTiroArmaMenorId { get; set; }
        public int? TipoPersonalMilitarId { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public string? FechaEjercicio { get; set; }
        public int? TipoArmamentoId { get; set; }
        public int? PosicionTipoArmaId { get; set; }
        public decimal? DistanciaMetros { get; set; }
        public int? CantidadTiro { get; set; }
        public int? PorcentajeEvaluacion { get; set; }



        public string? DescTipoPersonalMilitar { get; set; }
        public string? DescGradoPersonalMilitar { get; set; }
        public string? DescTipoArmamento { get; set; }
        public string? DescPosicionTipoArma { get; set; }




        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }


    }
}
