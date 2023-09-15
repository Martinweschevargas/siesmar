using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class EjercicioTipoArmaMenorComestreDTO
    {

        public int? EjercicioTipoArmaMenorComestreId { get; set; }
        public int? EspecialidadGenericaPersonalId { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public string? FechaEjercicio { get; set; }
        public int? TipoArmamentoId { get; set; }
        public string? Posicion { get; set; }
        public int? DistanciaMetro { get; set; }
        public int? CantidadTipo { get; set; }


        public string? DescEspecialidad { get; set; }
        public string? DescGrado { get; set; }
        public string? DescTipoArmamento { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}