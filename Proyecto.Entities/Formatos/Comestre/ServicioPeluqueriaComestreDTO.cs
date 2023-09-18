using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class ServicioPeluqueriaComestreDTO
    {

        public int? ServicioPeluqueriaComestreId { get; set; }
        public string? Fecha { get; set; }
        public int? CIPPersonal { get; set; }
        public int? GradoPersonalMilitarId { get; set; }
        public int? EspecialidadGenericaPersonalId { get; set; }
        public int? DependenciaId { get; set; }


        public string? DescGrado { get; set; }
        public string? DescEspecialidad { get; set; }
        public string? DescDependencia{ get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}